using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;
using OfficeOpenXml;
using OfficeOpenXml.Drawing;

namespace SIEM_PROJECT
{
    public partial class Form1 : Form
    {
        private Dictionary<string, List<int>> terminals = new Dictionary<string, List<int>>();
        private Dictionary<string, List<Tuple<string, string>>> productionRules = new Dictionary<string, List<Tuple<string, string>>>();
        private string xmlFilePath;
        private string excelFilePath;
        private string currentState;
        private int DailyLimit;
        private HashSet<string> bannedSet = new HashSet<string>();
        private Dictionary<string, Dictionary<DateTime, int>> pcDateCount = new Dictionary<string, Dictionary<DateTime, int>>();

        List<string> computerNames = new List<string>();
        List<string> timeGenerated = new List<string>();
        List<string> eventIdsList = new List<string>();
        List<string> eventTypes = new List<string>();
        List<string> source = new List<string>();
        List<string> message = new List<string>();
        List<string> eventTypeNames = new List<string>();
        List<List<string>> events = new List<List<string>>();

        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBanList();
        }

        private void LoadBanList()
        {
            if (File.Exists("banlist.txt"))
            {
                using (StreamReader reader = new StreamReader("banlist.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        bannedSet.Add(line.Trim());
                    }
                }
            }
        }

        private void buttonLoadXml_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.Title = "Select XML file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xmlFilePath = openFileDialog.FileName;
                    textBoxOutput.AppendText($"Selected XML file: {xmlFilePath}\r\n");
                    LoadXmlFile(xmlFilePath);
                }
            }
        }

        private void buttonLoadExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.Title = "Select Excel file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    excelFilePath = openFileDialog.FileName;
                    textBoxOutput.AppendText($"Selected Excel file: {excelFilePath}\r\n");
                    LoadExcelFile(excelFilePath);
                }
            }
        }

        private void LoadXmlFile(string path)
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);

            try
            {
                settings.XmlResolver = new XmlUrlResolver();

                using (XmlReader reader = XmlReader.Create(path, settings))
                {
                    terminals.Clear();
                    productionRules.Clear();
                    textBoxOutput.Clear();
                    string startVariable = string.Empty;

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "Terminal")
                            {
                                string terminalName = reader.GetAttribute("name");
                                reader.ReadToDescendant("Values");
                                string valuesString = reader.ReadElementContentAsString();
                                List<int> values = ParseValues(valuesString);
                                terminals.Add(terminalName, values);
                            }
                            else if (reader.Name == "Production")
                            {
                                reader.ReadToDescendant("Left");
                                string left = reader.ReadElementContentAsString();
                                reader.ReadToFollowing("Term");
                                string terminal = reader.ReadElementContentAsString();
                                reader.ReadToFollowing("Right");
                                string right = reader.ReadElementContentAsString();

                                if (!productionRules.ContainsKey(left))
                                {
                                    productionRules[left] = new List<Tuple<string, string>>();
                                }

                                productionRules[left].Add(new Tuple<string, string>(terminal, right));
                            }
                            else if (reader.Name == "StartVariable")
                            {
                                startVariable = reader.ReadElementContentAsString();
                            }
                            else if (reader.Name == "DailyLimit")
                            {
                                DailyLimit = int.Parse(reader.ReadElementContentAsString());
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(startVariable))
                    {
                        currentState = startVariable;
                        textBoxOutput.AppendText($"Start Variable: {currentState}\r\n");
                    }
                    else
                    {
                        textBoxOutput.AppendText("Start Variable not found in the XML.\r\n");
                    }

                    if(DailyLimit != 0)
                    {
                        textBoxOutput.AppendText($"Daily Limit: {DailyLimit}\r\n");
                    }
                    else
                    {
                        textBoxOutput.AppendText("Daily Limit not found in the XML.\r\n");
                    }


                    

                    foreach (var terminal in terminals)
                    {
                        textBoxOutput.AppendText($"Terminal: {terminal.Key}, Values: {string.Join(", ", terminal.Value)}\r\n");
                    }

                    foreach (var rule in productionRules)
                    {
                        foreach (var transition in rule.Value)
                        {
                            textBoxOutput.AppendText($"Production: {rule.Key} -> {transition.Item1}{transition.Item2}\r\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }


        private void LoadExcelFile(string path)
        {
            computerNames.Clear();
            timeGenerated.Clear();
            eventIdsList.Clear();
            eventTypes.Clear();
            message.Clear();
            source.Clear();
            eventTypeNames.Clear();
            try
            {
                using (var package = new ExcelPackage(new System.IO.FileInfo(path)))
                {
                    var worksheet = package.Workbook.Worksheets[0]; // Get the first worksheet
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++) // Skip header row
                    {
                        computerNames.Add(($"{worksheet.Cells[row, 2].Text}\t"));
                        timeGenerated.Add(($"{worksheet.Cells[row, 3].Text}\t"));
                        eventIdsList.Add(($"{worksheet.Cells[row, 4].Text}\t"));
                        eventTypes.Add(($"{worksheet.Cells[row, 5].Text}\t"));
                        eventTypeNames.Add(($"{worksheet.Cells[row, 6].Text}\t"));
                        source.Add(($"{worksheet.Cells[row, 7].Text}\t"));
                        message.Add(($"{worksheet.Cells[row, 8].Text}\t"));
                        events.Add(new List<string> { computerNames[row - 2], timeGenerated[row - 2], eventIdsList[row - 2], eventTypes[row - 2], eventTypeNames[row - 2], source[row - 2], message[row - 2] });
                    }

                    textBoxOutput.AppendText("Event IDs along with Event Types loaded successfully from the Excel file.\r\n");
                    for (int i = 0; i < eventIdsList.Count; i++)
                    {
                        textBoxOutput.AppendText($"Event ID: {eventIdsList[i]}, Event Type: {eventTypeNames[i]}\r\n");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            buttonView.Visible = false;
            buttonSave.Visible = false;
            buttonBanlist.Visible = false;
            txtBoxProcess.Clear();
            ProcessEvents();
        }

        private void ProcessEvents()
        {
            if (string.IsNullOrEmpty(xmlFilePath))
            {
                MessageBox.Show("Select an XML file first.");
                return;
            }

            if (eventIdsList.Count == 0)
            {
                MessageBox.Show("Select an Excel file first.");
                return;
            }

            if (string.IsNullOrEmpty(currentState))
            {
                MessageBox.Show("Could not load Start Variable from the XML file. Your XML file may be invalid.");
                return;
            }

            if (string.IsNullOrEmpty(DailyLimit.ToString()))
            {
                MessageBox.Show("Could not load Daily Limit from the XML file. Your XML file may be invalid.");
                return;
            }

            bool listUpdated = false;

            Dictionary<string, Dictionary<DateTime, int>> pcDateCount = new Dictionary<string, Dictionary<DateTime, int>>();

            using (StreamWriter reportWriter = new StreamWriter("report.txt", append: false)) // Create a new report file
            {
                foreach (List<string> ev in events)
                {
                    string input = ev[2];
                    string pcName = ev[0].Trim();
                    DateTime date;
                    if (!DateTime.TryParse(ev[1], out date))
                    {
                        txtBoxProcess.AppendText($"Invalid date format: {ev[1]}\r\n");
                        continue;
                    }
                    date = date.Date;

                    if (bannedSet.Contains(pcName))
                    {
                        reportWriter.WriteLine($"Already banned computer {pcName} attempted an operation at {ev[1]}.\r\n");
                        txtBoxProcess.AppendText($"Already banned computer {pcName} attempted an operation.\r\n");
                        continue;
                    }

                    bool transitioned = false;
                    txtBoxProcess.AppendText($"Processing input: {input}\r\n");

                    if (terminals["C"].Contains(int.Parse(input)))
                    {
                        reportWriter.WriteLine($"Possible Violation! - EventID: {input} - Computer Name: {pcName} - Violation Date: {ev[1]}\r\n");

                        if (!pcDateCount.ContainsKey(pcName))
                        {
                            pcDateCount[pcName] = new Dictionary<DateTime, int>();
                        }

                        if (!pcDateCount[pcName].ContainsKey(date))
                        {
                            pcDateCount[pcName][date] = 0;
                        }

                        pcDateCount[pcName][date]++;
                        if (pcDateCount[pcName][date] >= DailyLimit)
                        {
                            bannedSet.Add(pcName);
                            listUpdated = true;
                            reportWriter.WriteLine($"Banned: {pcName} as it reached {DailyLimit} critical events on {date}\r\n");
                            txtBoxProcess.AppendText($"Banned: {pcName}\r\n");
                            continue; // Proceed to the next event without further processing
                        }
                    }

                    if (productionRules.ContainsKey(currentState))
                    {
                        foreach (var transition in productionRules[currentState])
                        {
                            if (terminals.ContainsKey(transition.Item1) && terminals[transition.Item1].Contains(int.Parse(input)))
                            {
                                txtBoxProcess.AppendText($"State Transition: {currentState} -> {transition.Item2} on input {input} {pcName}\r\n");
                                currentState = transition.Item2;
                                transitioned = true;
                                break;
                            }
                        }

                        if (!transitioned)
                        {
                            txtBoxProcess.AppendText("No valid transition found.\r\n");
                        }
                    }
                    else
                    {
                        txtBoxProcess.AppendText($"No production rule for current state: {currentState}\r\n");
                    }

                    if (!transitioned)
                    {
                        break;
                    }
                }

                txtBoxProcess.AppendText($"Final State: {currentState}\r\n");

                using (StreamWriter writer = new StreamWriter("banlist.txt"))
                {
                    foreach (var banned in bannedSet)
                    {
                        writer.WriteLine(banned);
                    }   
                }
                if (listUpdated)
                {
                    txtBoxProcess.AppendText("Ban list successfully created.\r\n");
                }
                else
                {
                    txtBoxProcess.AppendText("No new bans were made.\r\n");
                }

                txtBoxProcess.AppendText("Processing completed.\r\n");

                buttonSave.Visible = true;
                buttonView.Visible = true;
                buttonBanlist.Visible = true;
            }
        }



        private void ValidationCallback(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                textBoxOutput.AppendText($"Uyarı: {e.Message}\r\n");
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                if (e.Message.Contains("The element")) // DTD uygunluğunu kontrol etmek için özel bir mesaj kontrolü
                {
                    textBoxOutput.AppendText($"Hata: {e.Message}\r\n");
                }
                else
                {
                    textBoxOutput.AppendText($"Hata: XML dosyası DTD'ye uymuyor.\r\n");
                }
            }
        }


        private List<int> ParseValues(string valuesString)
        {
            List<int> values = new List<int>();
            string[] parts = valuesString.Split(',');

            foreach (var part in parts)
            {
                if (part.Contains('-'))
                {
                    string[] rangeParts = part.Split('-');
                    int start = int.Parse(rangeParts[0]);
                    int end = int.Parse(rangeParts[1]);

                    for (int i = start; i <= end; i++)
                    {
                        values.Add(i);
                    }
                }
                else
                {
                    values.Add(int.Parse(part));
                }
            }

            return values;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
            File.Copy("report.txt", filePath, overwrite: true);
            txtBoxProcess.AppendText($"Report saved to {filePath}\r\n");
            buttonSave.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // open the txt file
            try
            {
                System.Diagnostics.Process.Start("report.txt");
            }
            catch (Exception)
            {
                txtBoxProcess.AppendText("There has been an error opening the file.\r\n");
            }
        }

        private void buttonBanlist_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("banlist.txt");
            }
            catch (Exception)
            {
                txtBoxProcess.AppendText("There has been an error opening the file.\r\n");
            }
        }
    }
}

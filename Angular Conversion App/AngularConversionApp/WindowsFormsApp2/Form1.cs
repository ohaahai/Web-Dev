
// Code to convert some basic AngularJS files to Angular for Migration to Angular.!!!! 



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            button1.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            FileStream fileStream = File.Open("C:/AngularConversionApp/project_required/files/practice_component1", FileMode.Open);
            fileStream.SetLength(0);
            fileStream.Close();
            FileStream fileStream1 = File.Open("C:/AngularConversionApp/project_required/files/practice_html", FileMode.Open);
            fileStream1.SetLength(0);
            fileStream1.Close();

            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();
            //clear file
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", String.Empty);

            //copy basic code to component file
            string str2 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\component.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", str2);

            //copy basic code to module file
            string str3 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\module.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_module.txt", str3);

            string str4 = File.ReadAllText(@"c:\AngularConversionApp\project_required\angular2_basic_files\html.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_html.txt", str4);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {

                //clear file
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_html.txt", String.Empty);


                label2.Text = openFileDialog2.FileName;
                //read line by line
                string str = File.ReadAllText(label2.Text);
                //replace
                str = str.Replace("ng-model", "[(ngModel)]");



                //replace
                str = str.Replace("</div>", " ");



                //replace
                str = str.Replace("ng-repeat=\"", "*ngFor=\"let ");

                str = str.Replace("in ", "of ");

                str = str.Replace("vm.", " ");

                //replace
                str = str.Replace("ng-class=\"{", "[ngClass]=\"{\'");

                //replace
                str = str.Replace("ng-click", "(click)");

                //replace
                str = str.Replace("ng-if", "ngIf ");

                //replace
                str = str.Replace(" ng-show=\"", "[hidden]=\"!");

                //replace
                str = str.Replace(" ng-src=\"{{", "[src]=\"");


                //replace
                str = str.Replace("ng-href=\"{{", "[href]=\"");

                //replace
                str = str.Replace("}}\">", "\">");

                //replace
                str = str.Replace(":", "\':");

                //replace
                str = str.Replace(",", ",\'");


                //replace
                str = str.Replace("href=\"#!", "routerLink=\"/");

                //replace
                str = str.Replace("ng-switch", "[ngSwitch]");


                //replace
                str = str.Replace("ng-switch-when", "*ngSwitchCase");

                //replace
                str = str.Replace("ng-switch-default", "*ngSwitchDefault");

                //replace
                str = str.Replace("ng-style=\"{", " [ngStyle]=\"{\'");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_html.txt", str);

                // adding router-outlet tag
                if (File.ReadAllText(@"C:\AngularConversionApp\project_required\files\practice_html").Contains("routerLink"))
                {
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_html.txt", "<router-outlet></router-outlet>");

                }



                var oldLines = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/practice_html.txt");
                var newLines = oldLines.Where(line => !line.Contains("ng-controller"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/practice_html.txt", newLines);

                var oldLines1 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/practice_html.txt");
                var newLines1 = oldLines1.Where(line => !line.Contains("script"));

                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/practice_html.txt", newLines1);

                //var oldLines2 = System.IO.File.ReadAllLines("d:/project_required/practice_html.txt");
                //var newLines2 = oldLines2.Where(line => !line.Contains("angular.module"));

                //System.IO.File.WriteAllLines("d:/project_required/practice_html.txt", newLines2);

                string search_text = "head";

                string old;
                string n = "";
                StreamReader sr = File.OpenText("C:/AngularConversionApp/project_required/practice_html.txt");
                while ((old = sr.ReadLine()) != null)
                {
                    if (!old.Contains(search_text))
                    {
                        n += old + Environment.NewLine;
                    }
                }
                sr.Close();
                File.WriteAllText("C:/AngularConversionApp/project_required/practice_html.txt", n);

                string search_text1 = "body";
                string old1;
                string n1 = "";
                StreamReader sr1 = File.OpenText("C:/AngularConversionApp/project_required/practice_html.txt");
                while ((old1 = sr1.ReadLine()) != null)
                {
                    if (!old1.Contains(search_text1))
                    {
                        n1 += old1 + Environment.NewLine;
                    }
                }
                sr1.Close();
                File.WriteAllText("C:/AngularConversionApp/project_required/practice_html.txt", n1);


                string search_text2 = "html";
                string old2;
                string n2 = "";
                StreamReader sr2 = File.OpenText("C:/AngularConversionApp/project_required/practice_html.txt");
                while ((old2 = sr2.ReadLine()) != null)
                {
                    if (!old2.Contains(search_text2))
                    {
                        n2 += old2 + Environment.NewLine;
                    }
                }
                sr2.Close();
                File.WriteAllText("C:/AngularConversionApp/project_required/practice_html.txt", n2);

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_html.txt", "\n \\\\ write ** <base href=\" / \"> ** in index.html if routing is used ");


                richTextBox1.Text = File.ReadAllText("C:/AngularConversionApp/project_required/practice_html.txt");



            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //clear file
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", String.Empty);



                //copy basic code to component file
                string str2 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\component.txt");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", str2);

                //copy basic code to module file
                string str3 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\module.txt");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_module.txt", str3);



                label1.Text = openFileDialog1.FileName;


                string str31 = File.ReadAllText(label1.Text);
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", str31);



                var oldLines = System.IO.File.ReadAllLines(@"C:\AngularConversionApp\project_required\practice_component1.txt");
                var newLines = oldLines.Where(line => !line.Contains("controller"));
                System.IO.File.WriteAllLines(@"C:\AngularConversionApp\project_required\practice_component1.txt", newLines);

                //selectin reading ...replacing and copying
                string str = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt");
                str = str.Replace("$scope.", "");



                //replace
                str = str.Replace("});", "");



                //replace
                str = str.Replace(");", "");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", str);


                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", "}");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt", "\n\n//** see if all the braces are balanced **");



                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_component1.txt");

            }
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog3.FileName;

                // reading service name
                string val = File.ReadAllText(label3.Text);
                Match match = Regex.Match(val, "\'([^\"]*)\'");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", yourValue);
                }


                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{");

                var oldLines = System.IO.File.ReadAllLines(label3.Text);
                var newLines = oldLines.Where(line => !line.Contains("service"));
                System.IO.File.AppendAllLines("C:/AngularConversionApp/project_required/files/service", newLines);

                var oldLines1 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines1 = oldLines1.Where(line => !line.Contains("controller"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines1);

                var oldLines12 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines2 = oldLines12.Where(line => !line.Contains("factory"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines2);


                var oldLines13 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines3 = oldLines13.Where(line => !line.Contains("provider"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines3);

                ////removing  function..
                //string[] fileLines = File.ReadAllLines(@"D:\project_required\files\service");

                //for (int i = 0; i < fileLines.Length; i++)
                //{
                //    int start = fileLines[i].IndexOf("=");
                //    int end = fileLines[i].LastIndexOf(" ");
                //    if (start >= 0 && end >= 0)
                //    {
                //        fileLines[i] = fileLines[i].Substring(0, start) + fileLines[i].Substring(end + 1);
                //    }
                //}
                //File.WriteAllLines(@"D:\project_required\files\service", fileLines);

                string str = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service");
                //replace
                str = str.Replace("= function", "");



                //replace
                str = str.Replace("=function", "");



                //replace
                str = str.Replace("this.", "");


                //replace
                str = str.Replace("$scope.", "this.");


                //replace
                str = str.Replace("$timeout(function ()", "constructor(){ \n setTimeout(()=>");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\files\service", str);



                string str12 = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service");
                //replace
                str12 = str12.Replace("});", "");

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str12);

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "}");

                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");

            }

        }

        private void openFileDialog3_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service1", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service1.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);

            if (openFileDialog5.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog5.FileName;





                // reading service name
                string val = File.ReadAllText(label3.Text);
                Match match = Regex.Match(val, "\'([^\"]*)\'");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", yourValue);
                }


                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{\n constructor(private http:Http) { } \n ngOnInit() {");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\n\n// write variables here and then \": any;\"\n\n");



                var oldLines1 = System.IO.File.ReadAllLines(label3.Text);
                var newLines1 = oldLines1.Where(line => !line.Contains("controller"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service1", newLines1);

                string str = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service1");
                //replace
                str = str.Replace("$scope.", "this.");



                //replace
                str = str.Replace(".then(function(response) {", ".subscribe(response => {");



                //replace
                str = str.Replace(".then(function(response){", ".subscribe(response => {");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\files\service1", str);



                string str12 = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service1");
                //replace
                str12 = str12.Replace("$http.get", "this.http.get<any>");

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str12);



                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");

            }
        }

        private void openFileDialog4_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Visible = false;
            button6.Visible = false;
            button1.Visible = true;
            button10.Visible = true;
            button11.Visible = true;
            button8.Visible = true;
            button9.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service2", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service2.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);

            if (openFileDialog6.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog6.FileName;

                var oldLines1 = System.IO.File.ReadAllLines(label3.Text);
                var newLines1 = oldLines1.Where(line => !line.Contains("module"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service2", newLines1);



                string val = File.ReadAllText("C:/AngularConversionApp/project_required/files/service2");
                Match match = Regex.Match(val, "\'([^\"]*)\'");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", yourValue);
                }

                var oldLines11 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service2");
                var newLines11 = oldLines11.Where(line => !line.Contains("controller"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service2", newLines11);


                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\nconstructor(private location: Location) {\n");

                string str = File.ReadAllText("C:/AngularConversionApp/project_required/files/service2");
                str = str.Replace("$scope.", "this.");



                str = str.Replace("$location.absUrl()", "(<any>this.location)._platformLocation.location.href");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str);

                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button4.Visible = false;
            button6.Visible = false;
            button8.Visible = false;
            button9.Visible = false;
            button10.Visible = false;
            button11.Visible = false;
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/route", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\route.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\files\route", str1);

            if (openFileDialog7.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog7.FileName;
                var oldLines1 = System.IO.File.ReadAllLines(label3.Text);
                var newLines1 = oldLines1.Where(line => !line.Contains("module"));
                System.IO.File.AppendAllLines("C:/AngularConversionApp/project_required/files/route", newLines1);

                var oldLines2 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/route");

                var newLines2 = oldLines2.Where(line => !line.Contains("($routeProvider)"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/route", newLines2);

                var oldLines3 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/route");
                var newLines3 = oldLines3.Where(line => !line.Contains("template"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/route", newLines3);

                string str = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\route");
                //replace
                str = str.Replace("\",{", "\',");

                //replace
                str = str.Replace("$routeProvider", "");

                //replace
                str = str.Replace("\" ,{", "\',");
                //replace
                str = str.Replace("\", {", "\',");

                //replace
                str = str.Replace("\',{", "\',");



                //replace
                str = str.Replace("\' ,{", "\',");


                //replace
                str = str.Replace("\', {", "\',");


                //replace
                str = str.Replace(".when(\"/", "{path: \'");


                //replace
                str = str.Replace(".when(\" /", "{ path:\'");



                //replace
                str = str.Replace(".when(\'/", "{path: \'");



                //replace
                str = str.Replace(".when(\' /", "{ path:\'");


                //replace
                str = str.Replace("controller :", "component : ");


                //replace
                str = str.Replace("controller:", "component : ");


                //replace
                str = str.Replace("}\n);", "},");


                //replace
                str = str.Replace("});});", "},");


                //replace
                str = str.Replace("});", "},");



                //replace
                str = str.Replace("})", "},");



                str = str.Replace(".otherwise({", "{ path: \'\' ,");


                //string str25 = File.ReadAllText(@"C:\desktop\AngularConversionApp\project_required\files\route");
                ////replace
                //str25 = str25.Replace("path: \'\'", "path: '', redirectTo: \'***write the first route page path here***\', pathMatch: \'full\'");
                //File.WriteAllText("D:/project_required/files/route", str25);



                //replace
                str = str.Replace("\", {", "");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", str);

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", "\n{ path: '**', component: PageNotFoundComponent }");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", "\n];");
                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", "\n\n export const routing: ModuleWithProviders = RouterModule.forRoot(routes);");
                //File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", "\n\n\n//keep single quotes for  path and remove quotes for components");

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", "\n\n\n//***check if all the braces are correctly balanced***");


                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_route.txt");
                richTextBox1.Text = richTextBox1.Text.Replace("\"", "");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);

            if (openFileDialog8.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog8.FileName;

                // reading service name
                string val = File.ReadAllText(label3.Text);
                Match match = Regex.Match(val, "\'([^\"]*)\',");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", yourValue);
                }


                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{\n myFunc{\n");

                var oldLines = System.IO.File.ReadAllLines(label3.Text);
                var newLines = oldLines.Where(line => !line.Contains("factory"));
                System.IO.File.AppendAllLines("C:/AngularConversionApp/project_required/files/service", newLines);

                var oldLines11 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines1 = oldLines11.Where(line => !line.Contains(":function"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines1);

                var oldLines1 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines11 = oldLines1.Where(line => !line.Contains(": function"));
                System.IO.File.WriteAllLines("C:/desktop/AngularConversionApp/project_required/files/service", newLines11);

                var oldLines2 = System.IO.File.ReadAllLines("C:/desktop/AngularConversionApp/project_required/files/service");
                var newLines2 = oldLines2.Where(line => !line.Contains("return{"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines2);

                var oldLines23 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines23 = oldLines23.Where(line => !line.Contains("return {"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines23);

                string str12 = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service");
                //replace
                str12 = str12.Replace("});", "");

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str12);

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "}");

                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service.txt");
            File.WriteAllText("C:/AngularConversionApp/project_required/files/service", str1);

            if (openFileDialog9.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog9.FileName;

                // reading service name
                string val = File.ReadAllText(label3.Text);
                Match match = Regex.Match(val, "\'([^\"]*)\',");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText("C:/AngularConversionApp/project_required/files/service", yourValue);
                }


                File.AppendAllText("C:/AngularConversionApp/project_required/files/service", "{\n myFunc{\n");

                var oldLines = System.IO.File.ReadAllLines(label3.Text);
                var newLines = oldLines.Where(line => !line.Contains("provider"));
                System.IO.File.AppendAllLines("C:/AngularConversionApp/project_required/files/service", newLines);

                var oldLines1 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines1 = oldLines1.Where(line => !line.Contains("function()"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines1);

                var oldLines2 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service");
                var newLines2 = oldLines2.Where(line => !line.Contains("return {"));
                System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service", newLines2);

                string str111 = File.ReadAllText("C:/AngularConversionApp/project_required/files/service");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str111);

                var oldLines12 = System.IO.File.ReadAllLines(@"C:\AngularConversionApp\project_required\practice_service.txt");
                var newLines12 = oldLines12.Where(line => !line.Contains("return"));
                System.IO.File.WriteAllLines(@"C:\AngularConversionApp\project_required\practice_service.txt", newLines12);


                string stringToSearch = @"return";
                string[] lines = File.ReadAllLines("C:/AngularConversionApp//project_required/files/service");
                foreach (string line in lines)
                {
                    if (line.Contains(stringToSearch))
                    {
                        File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", line);
                    }
                }
                string str1111 = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");
                File.WriteAllText("C:/AngularConversionApp/project_required/files/service", str1111);

                string str = File.ReadAllText("C:/AngularConversionApp/project_required/files/service");
                //replace
                str = str.Replace("}};", "");

                //replace
                str = str.Replace("};});", "}");

                str = str.Replace("}}};", "");


                //replace
                str = str.Replace("});", "}");
                File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str);

                File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\n}");
                richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service.txt");
            File.WriteAllText("C:/AngularConversionApp/project_required/files/service", str1);

            if (openFileDialog10.ShowDialog() == DialogResult.OK)
            {
                label3.Text = openFileDialog10.FileName;
                string val = File.ReadAllText(label3.Text);
                Match match = Regex.Match(val, "\'([^\"]*)\',");
                if (match.Success)
                {
                    string yourValue = match.Groups[1].Value;

                    File.AppendAllText("C:/AngularConversionApp/project_required/files/service", yourValue);
                }

                File.AppendAllText("C:/AngularConversionApp/project_required/files/service", "{\n return ");

                string val1 = File.ReadAllText("C:/AngularConversionApp/project_required/files/service");
                Match match1 = Regex.Match(val, ",([^\"]*);");
                if (match1.Success)
                {
                    string yourValue1 = match1.Groups[1].Value;

                    File.AppendAllText("C:/AngularConversionApp/project_required/files/service", yourValue1);
                }
                File.AppendAllText("C:/AngularConversionApp/project_required/files/service", "\n");

                string val11 = File.ReadAllText("C:/AngularConversionApp/project_required/files/service");
                Match match11 = Regex.Match(val, "\"([^\"]*)\"");
                if (match11.Success)
                {
                    string yourValue11 = match11.Groups[1].Value;

                    File.AppendAllText("C:/AngularConversionApp/project_required/files/service", "\"" + yourValue11 + "\"");
                }


                File.AppendAllText("C:/AngularConversionApp/project_required/files/service", "\n}");
            }

            string str12 = File.ReadAllText(@"C:\AngularConversionApp\project_required\files\service");
            //replace
            str12 = str12.Replace("})", "}");


            //replace
            str12 = str12.Replace("\"); ", "");

            File.WriteAllText(@"C:/AngularConversionApp\project_required\files\service", str12);

            string str11 = File.ReadAllText("C:/AngularConversionApp/project_required/files/service");
            File.WriteAllText(@"C:/AngularConversionApp\project_required\practice_service.txt", str11);

            richTextBox1.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");
        }

            private void button11_Click(object sender, EventArgs e)
            {

            }

            private void button12_Click(object sender, EventArgs e)
            {
                button4.Visible = true;
                button6.Visible = true;
                button8.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
                button11.Visible = false;
                button1.Visible = false;
            }
        }
    }

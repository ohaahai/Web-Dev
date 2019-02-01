// Form Application for the conversion of an AngularJS module into an Angular 2 Component.
// Build start Date : 6/15/2018
/* Data Reference From ------
 * https://angular.io/guide/ajs-quick-reference
 * https://stackblitz.com/
*/
// The Source Code is supposed to have distunguished spaces.
// Start either by selecting a js file or directly insert the code into the Editor.




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
using System.Collections;
using System.Text.RegularExpressions;

namespace Conversion_App
{
    public partial class Angular : Form
    {

        string source_code;
        int type = 0;

        public Angular()
        {
            InitializeComponent();

        }



        // (Select File) Button.
        private void button1_Click(object sender, EventArgs e)
        {
            Enter_Code.Visible = false;

            Stream mystream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((mystream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    source_code = File.ReadAllText(strfilename);
                    InputBox.Text = source_code;
                }
            }


            OutputBox.Items.Clear(); // clear Outputbox each time a new file is selected.
            Select_File.Visible = true;
            InputBox.Visible = true;
            OutputBox.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            Convert.Visible = true;

        }

        // (Enter Code) Button.
        private void button2_Click(object sender, EventArgs e)
        {
            InputBox.Clear();
            Select_File.Visible = true;
            OutputBox.Visible = true;
            Convert.Visible = true;
            Enter_Code.Visible = false;
            InputBox.Visible = true;
            label2.Visible = true;
            label3.Visible = true;

        }








        // Function for conversion of Module
        public void ConvertModule()
        {

            //Referenced in accordance with stackblitz.com for testing
            OutputBox.Items.Add("import { Component } from '@angular/core';");
            OutputBox.Items.Add(" "); // Acts as new line character
            OutputBox.Items.Add("@Component({   ");


            List<string> div_contents = new List<string>(); // This Contains the HTML part of the code.
            Stack div_stack = new Stack(); // This Contains the <div , <div> and </div> tags.
            Queue scopes = new Queue();    // This Contains the $scope. parts.
            bool continue_read = false;    // Bool that refers whether the HTML contents is found.
            bool isamodule = false;        // Bool that refers whether the input file is a module or not.

            //Source Code in RichTextBox.
            string[] RichTextBoxLines = InputBox.Lines;

            //Traversal for html and scopes extraction.
            foreach (string line in RichTextBoxLines)
            {

                // A temporary string that contains the current working line of the source code.
                string s = line;

                // Split string on spaces.
                string[] words = s.Split(' ');
                foreach (string word in words)
                {

                    //Treatment for ng-app.
                    if (word.Length >= 7 && word.Substring(0, 7) == "ng-app=")
                    {
                        string selector = "selector: '";
                        selector += word.Substring(8, word.Length - 9);
                        selector += "' ,";
                        OutputBox.Items.Add(selector);
                        isamodule = true;
                        continue;
                    }


                    // HTML Contents.
                    if (word == "<div" || word == "<div>")
                    {
                        div_stack.Push(word);
                        div_contents.Add("<div>");
                        // div_contents.Add("");  //Acts as new line character for listbox.
                        continue_read = true;

                    }

                    else if (word == "</div>")
                    {
                        //check if the js file is correct. Any extra </div> will be shown as error.
                        if (div_stack.Count == 0)
                        {
                            OutputBox.Items.Clear();
                            OutputBox.Items.Add("Error :: ");
                            OutputBox.Items.Add("-- The div element in the source file has extra </div> ");
                            return;
                        }


                        div_stack.Pop();
                        div_contents.Add(word);
                        continue_read = false;

                    }

                    else if (continue_read)
                    {
                        div_contents.Add(word);
                    }

                    // Finding scopes.
                    else if (word.Length >= 7 && word.Substring(0, 7) == "$scope.")
                    {
                        string tmp = word.Substring(7, word.Length - 7);
                        scopes.Enqueue(tmp);
                    }
                }

            }


            // If there is no ng-app in the input , that means its not a valid AngularJS module
            if (!isamodule)
            {
                OutputBox.Items.Clear();
                OutputBox.Items.Add("Error ::  ng-app not found. ");
                OutputBox.Items.Add("-- The Input Box does not contain a valid AngularJS module.");
                OutputBox.Items.Add("-- Tip :: Check for spaces in ng-app= ");
                return;
            }




            OutputBox.Items.Add("template: `");

            //conversion to angular 2+.
            foreach (string word in div_contents)
            {
                //Treatment for ng-controller.
                if (word.Length >= 13 && word.Substring(0, 13) == "ng-controller")
                {
                    continue;
                }

                //Treatment for ng-model.
                else if (word.Length >= 9 && word.Substring(0, 9) == "ng-model=")
                {
                    string temp = " [(ngModel)] = ";
                    temp += word.Substring(9, word.Length - 9);
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-class.
                else if (word.Length >= 9 && word.Substring(0, 9) == "ng-class=")
                {
                    string temp = " [ngClass] = ";
                    temp += word.Substring(9, word.Length - 9);
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-click.
                else if (word.Length >= 9 && word.Substring(0, 9) == "ng-click=")
                {
                    string temp = " (click) = ";
                    int index = word.Substring(9, word.Length - 9).IndexOf(".");// Find the index of '  .  '
                    temp += word.Substring(9, 1); // Add "
                    temp += word.Substring(9 + index + 1, word.Length - 9 - index - 1); // Remove all contents before .
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-href.
                else if (word.Length >= 8 && word.Substring(0, 8) == "ng-href=")
                {
                    string temp = " [href] = ";
                    temp += word.Substring(8, word.Length - 8);
                    temp = temp.Remove(11, 2);//remove {{
                    temp = temp.Remove(word.Length - 4, 2);//remove }}
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-if.
                else if (word.Length >= 6 && word.Substring(0, 6) == "ng-if=")
                {
                    string temp = " *ngIf = ";
                    temp += word.Substring(6, word.Length - 6);
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-repeat.
                else if (word.Length >= 10 && word.Substring(0, 10) == "ng-repeat=")
                {
                    string temp = " *ngFor = ";
                    temp += word.Substring(10, word.Length - 10);
                    temp = temp.Insert(11, " let "); // Insert let

                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-src.
                else if (word.Length >= 7 && word.Substring(0, 7) == "ng-src=")
                {
                    string temp = " [src] = ";
                    temp += word.Substring(7, word.Length - 7);
                    temp = temp.Remove(10, 2);//remove {{
                    temp = temp.Remove(word.Length - 4, 2);//remove }}
                    OutputBox.Items.Add(temp);

                }

                //Treatment for ng-style.
                else if (word.Length >= 9 && word.Substring(0, 9) == "ng-style=")
                {
                    string temp = " [ngStyle] = ";
                    temp += word.Substring(9, word.Length - 9);
                    int index1 = word.Substring(9, word.Length - 9).IndexOf(":");// Find the index of '  :  '
                    int index2 = word.Substring(9, word.Length - 9).IndexOf("{");// Find the index of '  {  '
                    temp = temp.Insert(9 + index1 + 4, " ' "); // Temp has to be shifted by 4
                    temp = temp.Insert(9 + index2 + 5, " ' ");// Temp has to be shifted by 5
                    OutputBox.Items.Add(temp);

                }

                else
                {
                    OutputBox.Items.Add(word);
                }
            }

            //Work on AppComponent.
            OutputBox.Items.Add("`");
            OutputBox.Items.Add("}) ");
            OutputBox.Items.Add("export class AppComponent  { ");

            foreach (string scope in scopes)
            {
                OutputBox.Items.Add(scope);
            }

            OutputBox.Items.Add("}");// End of AppComponent

        }










// Custom Service converter
        public void ConvertCustomService()
        {
            // Clear the Output Box.
            OutputBox.Items.Clear();


            //Referenced in accordance with stackblitz.com
            OutputBox.Items.Add("import { Injectable } from '@angular/core'; ");
            OutputBox.Items.Add(" "); // Acts as NewLine character
            OutputBox.Items.Add("@Injectable( )");
            OutputBox.Items.Add(" "); // Acts as NewLine character


            // Data Structures used.
            string service_type = "";
            string service_name = "";
            Queue functions = new Queue();
            bool isfound = false;


            //Source Code in InputBox.
            string[] InputBoxLines = InputBox.Lines;
            int n = InputBoxLines.Length;
            int index = -1;

            //Traversal one line at a time.
            foreach (string line in InputBoxLines)
            {
                string s = line;
                index++;

                // Split string on spaces.
                string[] words = s.Split(' ');
                foreach (string word in words)
                {

                    if ((word.Length >= 11 && word.Contains(".service")) || (word.Length >= 12 && word.Contains(".provider")) || (word.Length >= 9 && word.Contains(".value"))
                        || (word.Length >= 11 && word.Contains(".factory")) || (word.Length >= 12 && word.Contains(".constant")))
                    {

                        isfound = true;

                        int index1 = -1; // index of ,
                        int index2 = -1; // index of (
                        int index3 = -1; // index of .


                        //  Check for exixtance of ,
                        index1 = word.IndexOf(",");
                        if (index1 == -1)
                        {
                            OutputBox.Items.Clear();
                            OutputBox.Items.Add("Either , in app.sth('sth', is missing or there is a space before , in AngularJS Service Code.");
                            OutputBox.Items.Add("Please follow the Syntax as app.sth('sth', functions(){ ");
                            return;
                        }


                        //  Check for exixtance of (
                        index2 = word.Substring(0, index1).IndexOf("(");
                        if (index1 == -1)
                        {
                            OutputBox.Items.Clear();
                            OutputBox.Items.Add("Either ( in  app.sth(  is missing or there is a space before ( in AngularJS Service Code.");
                            OutputBox.Items.Add("Please follow the Syntax as app.sth('sth', functions(){ ");
                            return;
                        }

                        //  Check for exixtance of .
                        index3 = word.Substring(0, index2).IndexOf(".");
                        if (index1 == -1)
                        {
                            OutputBox.Items.Clear();
                            OutputBox.Items.Add(" The . in (app.) is missing in AngularJS Service Code.");
                            OutputBox.Items.Add("Please follow the Syntax as app.sth('sth', functions(){ ");
                            return;
                        }

                        /*
                        OutputBox.Items.Add(index1);
                        OutputBox.Items.Add(index2);
                        OutputBox.Items.Add(index3);
                        */

                        // Name of service
                        service_name = word.Substring(index2 + 2, index1 - index2 - 3);
                        // Type of service 
                        service_type = word.Substring(index3, index2 - index3);


                        string comment = "// This was a  ";
                        comment += service_type;
                        comment += " type of service";
                        OutputBox.Items.Add(comment);



                        // Work on export class class_name
                        string classLine = "export class ";
                        classLine += service_name;

                        // Treatment for {
                        if (word.Substring(word.Length - 1, 1) == "{")
                        {
                            classLine += " { ";
                        }
                        OutputBox.Items.Add(classLine);
                    }



                    // Find variables and methods according to thier service types
                    if (isfound)
                    {



                        // .service converter
                        // .service has this. parts visible
                        if (service_type == ".service")
                        {


                            //If this is a function
                            if (word.Length >= 5 && word.Substring(0, 5) == "this.")
                            {



                                // index of =
                                int index1 = -1;
                                index1 = word.IndexOf("=");
                                if (index1 == -1)
                                {
                                    OutputBox.Items.Clear();
                                    OutputBox.Items.Add("Either = in this.sth= is missing or there is a space before = in AngularJS Service Code.");
                                    OutputBox.Items.Add("Please follow the Syntax as this.sth=function() ");
                                    return;
                                }

                                // Name of Function
                                string func_name = "";
                                func_name = word.Substring(5, index1 - 5);// OutputBox.Items.Add(word.Substring(5, index1 - 5));


                                int index2 = -1;
                                index2 = word.IndexOf("(");
                                if (index1 == -1)
                                {
                                    OutputBox.Items.Clear();
                                    OutputBox.Items.Add("Either ( in this.sth=funvtion( is missing or there is a space before ( in AngularJS Service Code.");
                                    OutputBox.Items.Add("Please follow the Syntax as this.sth=function() ");
                                    return;
                                }

                                // Arguments of the function
                                string arguments = "";



                                // OutputBox.Items.Add(arguments);
                                arguments = word.Substring(index2, word.Length - index2);

                                // Put function and its arguments into the output box
                                OutputBox.Items.Add(func_name + arguments);



                            }


                            else if (word == "});")
                            {
                                OutputBox.Items.Add("}");
                                return;  // End of the service
                            }

                            else if ((word.Length >= 11 && word.Contains(".service")) || (word.Length >= 12 && word.Contains(".provider")) || (word.Length >= 9 && word.Contains(".value"))
                                     || (word.Length >= 11 && word.Contains(".factory")) || (word.Length >= 12 && word.Contains(".constant")))
                            {
                                continue;
                            }

                            else
                            {

                                OutputBox.Items.Add(word);
                            }

                        }





                        // .factory service converter
                        // .factory has return{ parts visible to controller
                        // I have considered that the service returns through a function not direct 

                        else if (service_type == ".factory")
                        {
                            // List of declarations
                            List<string> NonReturnContents = new List<string>();

                            // formatting of { 
                            if (!InputBoxLines[index].Contains("){"))
                            {
                                OutputBox.Items.Add("{ ");
                            }



                            bool fun = false; // This bool represents if a service function in found.

                            for (int i = index + 1; i < n; ++i)
                            {
                                // return{ or return {  is the separator of declarations with return statements
                                if (InputBoxLines[i].Contains("return{") || InputBoxLines[i].Contains("return {"))
                                {
                                    fun = true;
                                    continue;
                                }


                                else if (fun)
                                {

                                    // This is the line of the beginning of the return in the service
                                    if ((InputBoxLines[i].Contains(":")) && (InputBoxLines[i].Contains("function")) || (InputBoxLines[i].Contains("function ()")))
                                    {
                                        int index0 = InputBoxLines[i].IndexOf(":");
                                        OutputBox.Items.Add(InputBoxLines[i].Substring(0, index0) + "()"); // name of the service
                                        OutputBox.Items.Add("{");


                                        foreach (var tmpline in NonReturnContents)
                                        {
                                            OutputBox.Items.Add(tmpline);
                                        }


                                    }



                                    if (InputBoxLines[i] == "});")
                                    {
                                        OutputBox.Items.Add("}");
                                        return;  // }); represents End of service 
                                    }

                                    else
                                    {
                                        if ((InputBoxLines[i].Contains(":")) && (InputBoxLines[i].Contains("function")) || (InputBoxLines[i].Contains("function ()")))
                                        {

                                            // Skip the beginning line of the service
                                            continue;
                                        }
                                        else
                                        {

                                            // The local declarations in the return statement are made global.
                                            // This solves the duplication problem
                                            OutputBox.Items.Add(InputBoxLines[i]);
                                        }

                                    }

                                }

                                // These are the declarations and helper functions
                                else if (!fun)
                                {


                                    // Add all the declarations and the helper functions to the output
                                    // I have assumed that all the declarations are in the form 'var var_name = something' 
                                    // because angular syntax follows declarations with 'var' 
                                    // but in AngularJS they can be defined with or without 'var'
                                    NonReturnContents.Add(InputBoxLines[i]);
                                }
                            }

                            return;


                        }





                        // .provider converter
                        // .provider has this.$get parts visible to the controller
                        // The service must return through a function
                        // The return statements of helper functions shound end with } on the same line.

                        else if (service_type == ".provider")
                        {


                            // List of declarations
                            List<string> NonReturnContents = new List<string>();
                            Queue Functions = new Queue();
                            bool ret_found = false;
                            bool fun = false; // This bool represents if a this.$get function in found.


                            // formatting of { 
                            if (InputBoxLines[index].Contains("){") || InputBoxLines[index].Contains(") {"))
                            {
                                OutputBox.Items.Add("{ "); ;
                            }


                            for (int i = index + 1; i < n; ++i)
                            {

                                // The Visible part of the code is obtained
                                if (InputBoxLines[i].Contains("this.$get"))
                                {
                                    // Function found
                                    fun = true;
                                    continue;
                                }

                                // Work on Functions
                                if (fun)
                                {

                                    // The return statement
                                    if (InputBoxLines[i].Contains("return{") || InputBoxLines[i].Contains("return {"))
                                    {
                                        ret_found = true;
                                        continue;
                                    }

                                    // The local declarations are added to the NonReturnContents
                                    else if (ret_found)
                                    {

                                        // The functions are taken as the methods in Angular 2
                                        if (InputBoxLines[i].Contains(":"))
                                        {

                                            int index1 = -1;
                                            index1 = InputBoxLines[i].IndexOf(":");

                                            if (index1 != -1)
                                            {

                                                // Name of the function
                                                Functions.Enqueue(InputBoxLines[i].Substring(0, index1));

                                                // OutputBox.Items.Add(InputBoxLines[i].Substring(0, index1));

                                            }


                                        }


                                        // This return is the return statement of the helper functions
                                        else if (InputBoxLines[i].Contains("return"))
                                        {
                                            Functions.Enqueue(InputBoxLines[i]);
                                            //  Functions.Enqueue("}"); // End of the custom function
                                        }

                                        else
                                        {
                                            // Skip the brackets of return {     and  } of the custom functions
                                            if (InputBoxLines[i] != "}" && InputBoxLines[i] != "});" && InputBoxLines[i] != "};")
                                                NonReturnContents.Add(InputBoxLines[i]);
                                        }

                                    }


                                    // These are the declarations under this.$get
                                    else if (!ret_found)
                                    {
                                        // Ignore });
                                        if (InputBoxLines[i] == "});")
                                        {
                                            continue;
                                        }

                                        // Add the definitions to NonReturnContents
                                        NonReturnContents.Add(InputBoxLines[i]);
                                    }


                                }


                                // These are the declarations before this.$get
                                else if (!fun)
                                {
                                    // Ignore };
                                    if (InputBoxLines[i] == "};")
                                    {
                                        continue;
                                    }

                                    // Ignore });
                                    else if (InputBoxLines[i] == "});")
                                    {
                                        continue;
                                    }

                                    // Add the definitis to NonReturnContents
                                    NonReturnContents.Add(InputBoxLines[i]);

                                }

                            }


                            // Traverse through each helper funcions 
                            // This also contains theier corresponding return statements
                            foreach (string func in Functions)
                            {

                                // return doesnt need custom declarations
                                if (!func.Contains("return"))
                                {
                                    // Start of the function
                                    OutputBox.Items.Add(func + "{ ");

                                    // Each line declaraion for custom and helper functions
                                    foreach (var tmpline in NonReturnContents)
                                    {
                                        OutputBox.Items.Add(tmpline);

                                    }

                                }

                                // The start of the helper functions 
                                else
                                {
                                    OutputBox.Items.Add(func);
                                }

                            }

                            // close of funcions
                            OutputBox.Items.Add("}");
                            return;


                        }





                        // .value converter
                        // There should br No spaces in the service
                        else if (service_type == ".value")
                        {

                            OutputBox.Items.Add("{");

                            // index of ,
                            int index_tmp1 = -1;

                            if (word.Contains(","))
                            {
                                index_tmp1 = word.IndexOf(",");
                            }

                            // Test for error                
                            else
                            {
                                OutputBox.Items.Clear();
                                OutputBox.Items.Add("Either , in app.value('sth', is missing or there is a space before , in AngularJS Service Code.");
                                OutputBox.Items.Add("Please follow the Syntax as app.value('sth', values ");
                                OutputBox.Items.Add("Tip :: The service code in a .value has only one return value. Check if the value exists in a single line without spaces !!");
                                return;
                            }


                            // index of )
                            int index_tmp2 = -1;
                            if (word.Contains(")"))
                            {

                                index_tmp2 = word.IndexOf(")");
                            }

                            else
                            {
                                OutputBox.Items.Clear();
                                OutputBox.Items.Add("Either ) in app.value('sth',values) is missing or there is a space before ) in AngularJS Service Code.");
                                OutputBox.Items.Add("Please follow the Syntax as app.value('sth', values)");
                                OutputBox.Items.Add("Tip :: The service code in a .value has only one return value. Check if the value exists in a single line without spaces !!");
                                return;
                            }

                            // The return statement
                            string ret = "return ";
                            string ret_state = word.Substring(index_tmp1 + 1, index_tmp2 - index_tmp1 - 1);
                            OutputBox.Items.Add(ret + ret_state + ";");
                            OutputBox.Items.Add("}");
                            return;


                        }


                        // .constant converter
                        // There should br No spaces in the service
                        else if (service_type == ".constant")
                        {
                            OutputBox.Items.Add("{");

                            // index of ,
                            int index_tmp1 = -1;

                            if (word.Contains(","))
                            {
                                index_tmp1 = word.IndexOf(",");
                            }

                            // Test for error                
                            else
                            {
                                OutputBox.Items.Clear();
                                OutputBox.Items.Add("Either , in app.value('sth', is missing or there is a space before , in AngularJS Service Code.");
                                OutputBox.Items.Add("Please follow the Syntax as app.value('sth', values ");
                                OutputBox.Items.Add("Tip :: The service code in a .value has only one return value. Check if the value exists in a single line without spaces !!");
                                return;
                            }


                            // index of )
                            int index_tmp2 = -1;
                            if (word.Contains(")"))
                            {

                                index_tmp2 = word.IndexOf(")");
                            }

                            else
                            {
                                OutputBox.Items.Clear();
                                OutputBox.Items.Add("Either ) in app.value('sth',values) is missing or there is a space before ) in AngularJS Service Code.");
                                OutputBox.Items.Add("Please follow the Syntax as app.value('sth', values)");
                                OutputBox.Items.Add("Tip :: The service code in a .value has only one return value. Check if the value exists in a single line without spaces !!");
                                return;
                            }

                            // The return statement
                            string ret = "return ";
                            string ret_state = word.Substring(index_tmp1 + 1, index_tmp2 - index_tmp1 - 1);
                            OutputBox.Items.Add(ret + ret_state + ";");
                            OutputBox.Items.Add("}");
                            return;
                        }







                    }

                }


            }



            // If the bool variable 'isfound' is not true then, There is no service code present in the input
            if (!isfound)
            {
                OutputBox.Items.Clear();
                OutputBox.Items.Add("Error :: ");
                OutputBox.Items.Add("-- The Input File does not contain a custom service in AngularJS !!!");
                OutputBox.Items.Add("-- Please Enter a valid Service code into the Input Box.");
            }

        }















        // Convert button
        private void button3_Click(object sender, EventArgs e)
        {
            //Clear listbox.
            OutputBox.Items.Clear();

            // Error.
            if (type == 0)
            {
                OutputBox.Items.Clear();
                OutputBox.Items.Add("Please select the conversion type.");
                return;
            }


            // Module Conversion.
            else if (type == 1)
            {
                ConvertModule();
            }

            // Custom service Conversion.
            else if (type == 2)
            {
                ConvertCustomService();
            }

            // Predefined service conversion..
            else if (type == 3)
            {


                // This is the part for the predefined services conversion part.
                // This conversion is performed on the button itself.


            }


            else if (type == 4)
            {


                // This is the part for the Routes conversion part.
                // This conversion is performed on the button itself.

            }



            // Automatically Copy all the Contents of the listBox1/OutputBox to Clipboard.
            string s1 = "";
            foreach (object item in OutputBox.Items) s1 += item.ToString() + "\r\n";
            if (s1 != "")
            {
                Clipboard.SetText(s1);
            }

        }




        public void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // dynamic scrolling.
            InputBox.ScrollBars = RichTextBoxScrollBars.Both;
        }


        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // visible scrolling.
            OutputBox.HorizontalScrollbar = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void welcome_Click(object sender, EventArgs e)
        {

        }

        private void ModuleConverter_Click(object sender, EventArgs e)
        {
            type = 1;

            // Color Adjustment Of Buttons.
            Control ctrl = ((Control)sender);
            ctrl.BackColor = Color.White;
            PredefinedServiceConverter.BackColor = Color.Black;
            CustomServiceConverter.BackColor = Color.Black;
            RouteConverter.BackColor = Color.Black;


            groupBox2.Visible = true;
            Select_File.Visible = true;
            Enter_Code.Visible = true;
            InputBox.Visible = false;
            OutputBox.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            Convert.Visible = false;
            OutputBox.Items.Clear();


            InputBox.Clear();  // clear Inputbox each time a new file is selected. It maintains consistency.

        }

        private void CustomServiceConverter_Click(object sender, EventArgs e)
        {
            type = 2;

            // Color Adjustment Of Buttons.
            Control ctrl = ((Control)sender);
            ctrl.BackColor = Color.White;
            PredefinedServiceConverter.BackColor = Color.Black;
            ModuleConverter.BackColor = Color.Black;
            RouteConverter.BackColor = Color.Black;

            groupBox2.Visible = true;
            Select_File.Visible = true;
            Enter_Code.Visible = true;
            Convert.Visible = false;
            InputBox.Visible = false;
            OutputBox.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            OutputBox.Items.Clear();


            InputBox.Clear();  // clear Inputbox each time a new file is selected. It maintains consistency.

        }

        private void PredefinedServiceConverter_Click(object sender, EventArgs e)
        {

            type = 3;

            // Color Adjustment Of Buttons.
            Control ctrl = ((Control)sender);
            ctrl.BackColor = Color.White;
            ModuleConverter.BackColor = Color.Black;
            CustomServiceConverter.BackColor = Color.Black;
            RouteConverter.BackColor = Color.Black;


            // Follow this visibility if the conversion is done on click of convert button.
            /*
            groupBox2.Visible = true;
            button1.Visible = true;
            button2.Visible = true;
            Convert.Visible = false;
            InputBox.Visible = false;
            OutputBox.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            Convert.Visible = false;
            OutputBox.Items.Clear();
            */

            Select_File.Visible = false;
            Enter_Code.Visible = false;
            OutputBox.Visible = true;
            groupBox2.Visible = true;
            InputBox.Visible = true;
            Convert.Visible = false;
            label2.Visible = true;
            label3.Visible = true;




            OpenFileDialog openFileDialog5 = new OpenFileDialog();



            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/service1", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service1.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str1);


            string source_codejs = "";
            Stream mystreamjs;


            if (openFileDialog5.ShowDialog() == DialogResult.OK)
            {
                string file_name = openFileDialog5.FileName;

                if ((mystreamjs = openFileDialog5.OpenFile()) != null)
                {
                    OutputBox.Items.Clear();
                    InputBox.Clear();
                    string strfilename = openFileDialog5.FileName;
                    source_codejs = File.ReadAllText(strfilename);

                }




                string s = file_name;


                if (s.Contains("http"))

                {  // reading service name


                    string str121 = File.ReadAllText(file_name);
                    string str11 = str121.Split('\'', '\'')[1];
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str11);


                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{\n constructor(private http:Http) { } \n ngOnInit() {");
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\n\n// write variables here and then \": any;\"\n\n");



                    var oldLines1 = System.IO.File.ReadAllLines(file_name);
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


                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\n\n\n //this is an http service");
                    InputBox.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");
                }

                else if (s.Contains("location"))
                {

                    var oldLines1 = System.IO.File.ReadAllLines(file_name);
                    var newLines1 = oldLines1.Where(line => !line.Contains("module"));
                    System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service2", newLines1);





                    string str12 = File.ReadAllText("C:/AngularConversionApp/project_required/files/service2");
                    string str11 = str12.Split('\'', '\'')[1];
                    File.AppendAllText("C:/AngularConversionApp/project_required/files/service", str11);

                    var oldLines11 = System.IO.File.ReadAllLines("C:/AngularConversionApp/project_required/files/service2");
                    var newLines11 = oldLines11.Where(line => !line.Contains("controller"));
                    System.IO.File.WriteAllLines("C:/AngularConversionApp/project_required/files/service2", newLines11);


                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{");
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "\nconstructor(private location: Location) {\n");

                    string str = File.ReadAllText("C:/AngularConversionApp/project_required/files/service2");
                    str = str.Replace("$scope.", "this.");



                    str = str.Replace("$location.absUrl()", "(<any>this.location)._platformLocation.location.href");
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", str);
                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", " \n\n\n//this is an location service");
                    InputBox.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");

                }


                else if (s.Contains("timeout"))

                {

                    File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", String.Empty);
                    File.WriteAllText("C:/AngularConversionApp/project_required/files/service", String.Empty);
                    string str1a = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\service1.txt");
                    File.WriteAllText("C:/AngularConversionApp/project_required/files/service", str1a);


                    // reading service name
                    string val = File.ReadAllText(file_name);
                    Match match = Regex.Match(val, "\'([^\"]*)\'");
                    if (match.Success)
                    {
                        string yourValue = match.Groups[1].Value;

                        File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", yourValue);
                    }


                    File.AppendAllText(@"C:\AngularConversionApp\project_required\practice_service.txt", "{");

                    var oldLines = System.IO.File.ReadAllLines(file_name);
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

                    InputBox.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_service.txt");

                }

            }





            InputBox.Text = source_codejs;


            List<string> lines = new List<string>();
            using (StreamReader r = new StreamReader(@"C:\AngularConversionApp\project_required\practice_service.txt"))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            foreach (string line in lines)
            {
                OutputBox.Items.Add(line);
            }

            return;

        }



        // Route converter
        private void RouteConverter_Click(object sender, EventArgs e)
        {
            type = 4;

            // Color Adjustment Of Buttons
            Control ctrl = ((Control)sender);
            ctrl.BackColor = Color.White;
            PredefinedServiceConverter.BackColor = Color.Black;
            CustomServiceConverter.BackColor = Color.Black;
            ModuleConverter.BackColor = Color.Black;


            // Follow this visibility if the conversion is done on click of convert button.
            /* groupBox2.Visible = true;
             button1.Visible = true;
             button2.Visible = true;
             Convert.Visible = false;
             InputBox.Visible = false;
             OutputBox.Visible = false;
             label2.Visible = false;
             label3.Visible = false;
             Convert.Visible = false;
             OutputBox.Items.Clear();
             */

            Select_File.Visible = false;
            Enter_Code.Visible = false;
            OutputBox.Visible = true;
            groupBox2.Visible = true;
            InputBox.Visible = true;
            Convert.Visible = false;
            label2.Visible = true;
            label3.Visible = true;



            OpenFileDialog openFileDialog7 = new OpenFileDialog();


            string source_codejs = "";
            Stream mystreamjs;



            FileStream fileStream2 = File.Open("C:/AngularConversionApp/project_required/files/route", FileMode.Open);
            fileStream2.SetLength(0);
            fileStream2.Close();

            File.WriteAllText(@"C:\AngularConversionApp\project_required\practice_route.txt", String.Empty);

            string str1 = File.ReadAllText(@"C:\AngularConversionApp\project_required\angular2_basic_files\route.txt");
            File.WriteAllText(@"C:\AngularConversionApp\project_required\files\route", str1);

            if (openFileDialog7.ShowDialog() == DialogResult.OK)
            {
                string file_name = openFileDialog7.FileName;


                if ((mystreamjs = openFileDialog7.OpenFile()) != null)
                {
                    OutputBox.Items.Clear();
                    InputBox.Clear();
                    string strfilename = openFileDialog7.FileName;
                    source_codejs = File.ReadAllText(strfilename);

                }



                var oldLines1 = System.IO.File.ReadAllLines(file_name);
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

                InputBox.Text = File.ReadAllText(@"C:\AngularConversionApp\project_required\practice_route.txt");
                InputBox.Text = InputBox.Text.Replace("\"", "");


                InputBox.Text = source_codejs;


                List<string> lines = new List<string>();
                using (StreamReader r = new StreamReader(@"C:\AngularConversionApp\project_required\practice_route.txt"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }

                foreach (string line in lines)
                {
                    OutputBox.Items.Add(line);
                }

                return;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        // Solution to the flickering problem
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }


        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }

}


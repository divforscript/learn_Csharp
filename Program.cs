// Exercise: Complete a challenge to extract, replace, and remove data from an input string

const string input = "<div><h2>Widgets &trade;</h2><span>5000</span></div>";

string quantity = "";
string output = "";

// Your work here

int openSpanIndex = input.IndexOf("<s");
int closeSpanIndex = input.IndexOf("</s");
quantity = "Quantity: " + input.Substring(openSpanIndex + 6, 4);

// Set the output
output = input.Replace("<div>", "");
output = output.Replace("</div>", "");
output = "Output: " + output.Replace("&trade", "&reg");

Console.WriteLine(quantity);
Console.WriteLine(output);


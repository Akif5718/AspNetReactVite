#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BH.CodeGen.Templates.StoredProcedures
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#line 2 "EntitySelect.cshtml"
using BH.CodeGen;

#line default
#line hidden


[System.CodeDom.Compiler.GeneratedCodeAttribute("RazorTemplatePreprocessor", "2.6.0.0")]
public partial class EntitySelect : EntitySelectBase
{

#line hidden

#line 1 "EntitySelect.cshtml"
public BH.CodeGen.Model.Settings Model { get; set; }

#line default
#line hidden


public override void Execute()
{

#line 3 "EntitySelect.cshtml"
  
    var fullTableName = string.Format("[dbo].[{0}]", Model.ClassName);
    var fullSpName = string.Format("[dbo].[Select{0}]", Model.ClassName);
    WriteLiteral(
    $"--region PROCEDURE {fullSpName}\n" +
    $"IF OBJECT_ID('{fullSpName}') IS NOT NULL \n" +
    $"    BEGIN \n" +
    $"        DROP PROC {fullSpName} \n" +
    $"    END \n" +
    $"GO \n" +
    $"     \n" +
    $"CREATE PROC {fullSpName} \n" +
    $"( \n");
    WriteLiteral(
        $"\t@Page INT = 1,\n"+
        $"\t@PageSize INT = 10,\n"+
        $"\t@IsCountCalled BIT = 0,\n"+
        $"\t@SqlWhereClause NVARCHAR(500) = NULL\n"+
        $")\nAS\n"+
        $"BEGIN\n"+
        $"\tSET NOCOUNT ON\n"+
        $"\tSET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;\n\n"+
        $"\tDECLARE @FirstRec INT, @LastRec INT\n"+
        $"\tSELECT @FirstRec = (@Page - 1) * @PageSize\n"+
        $"\tSELECT @LastRec = (@Page * @PageSize + 1)\n\n"+
        $"\t-- local parameters to overcome parameter sniffing issue\n"+
        $"\tDECLARE\n"+
        $"\t\t@LocalSearch NVARCHAR(500) = ISNULL(LTRIM(RTRIM(@SqlWhereClause)), ''),\n"+
        $"\t\t@sqlRestltQuery NVARCHAR(500) = '',\n"+
        $"\t\t@Query NVARCHAR(MAX) = '',\n"+
        $"\t\t@ParmDefinition NVARCHAR(MAX);\n\n"+
        $"\tIF @IsCountCalled = 1\n"+
        $"\tBEGIN\n"+
        $"\t\tSET @sqlRestltQuery = N' SELECT count(RowNum) AS RecordCount FROM TempResult  ';\n"+
        $"\tEND\n"+
        $"\tELSE\n"+
        $"\tBEGIN\n"+
        $"\t\tSET @sqlRestltQuery = N' SELECT top (@LastRec-1) [tr].[RowNum],tr.* FROM TempResult AS [tr] WHERE [RowNum] > @FirstRec AND [RowNum] < @LastRec ' ;\n"+
        $"\tEND\n\n"+
        $"\tSET @Query = N'\n"+
        $"\t\t\t\tSELCT ROW_NUMBER() OVER(ORDER BY [Id]) as [RowNum], * FROM (\n"+
        $"\t\t\t\tSELECT * FROM {fullTableName}';\n\n"+
        $"\tSET @ParmDefinition = '@FirstRec int, @LastRec int';\n\n"+
        $"\tSET @Query ='BEGIN WITH TempResult as('+ @Query + ')  AS list WHERE '+ @LocalSearch +'  ) ' + @sqlRestltQuery +' END';\n\n" +
        $"\t--PRINT(@Query);\n\n"+
        $"\tEXEC sp_executesql @Query, @ParmDefinition, @FirstRec=@FirstRec, @LastRec= @LastRec;\n\n"+
        $"\tSET NOCOUNT OFF"+
        $"\tEND\nGO\n--endregion\n"
    );


#line default
#line hidden
WriteLiteral("\n\n");

}
}

// NOTE: this is the default generated helper class. You may choose to extract it to a separate file 
// in order to customize it or share it between multiple templates, and specify the template's base 
// class via the @inherits directive.
public abstract class EntitySelectBase
{

		// This field is OPTIONAL, but used by the default implementation of Generate, Write, WriteAttribute and WriteLiteral
		//
		System.IO.TextWriter __razor_writer;

		// This method is OPTIONAL
		//
		/// <summary>Executes the template and returns the output as a string.</summary>
		/// <returns>The template output.</returns>
		public string GenerateString ()
		{
			using (var sw = new System.IO.StringWriter ()) {
				Generate (sw);
				return sw.ToString ();
			}
		}

		// This method is OPTIONAL, you may choose to implement Write and WriteLiteral without use of __razor_writer
		// and provide another means of invoking Execute.
		//
		/// <summary>Executes the template, writing to the provided text writer.</summary>
		/// <param name="writer">The TextWriter to which to write the template output.</param>
		public void Generate (System.IO.TextWriter writer)
		{
			__razor_writer = writer;
			Execute ();
			__razor_writer = null;
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the template output without HTML escaping it.</summary>
		/// <param name="value">The literal value.</param>
		protected void WriteLiteral (string value)
		{
			__razor_writer.Write (value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes a literal value to the TextWriter without HTML escaping it.</summary>
		/// <param name="writer">The TextWriter to which to write the literal.</param>
		/// <param name="value">The literal value.</param>
		protected static void WriteLiteralTo (System.IO.TextWriter writer, string value)
		{
			writer.Write (value);
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>Writes a value to the template output, HTML escaping it if necessary.</summary>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected void Write (object value)
		{
			WriteTo (__razor_writer, value);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>Writes an object value to the TextWriter, HTML escaping it if necessary.</summary>
		/// <param name="writer">The TextWriter to which to write the value.</param>
		/// <param name="value">The value.</param>
		/// <remarks>The value may be a Action<System.IO.TextWriter>, as returned by Razor helpers.</remarks>
		protected static void WriteTo (System.IO.TextWriter writer, object value)
		{
			if (value == null)
				return;

			var write = value as Action<System.IO.TextWriter>;
			if (write != null) {
				write (writer);
				return;
			}

			//NOTE: a more sophisticated implementation would write safe and pre-escaped values directly to the
			//instead of double-escaping. See System.Web.IHtmlString in ASP.NET 4.0 for an example of this.
			writer.Write(System.Net.WebUtility.HtmlEncode (value.ToString ()));
		}

		// This method is REQUIRED, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to the template output.
		/// </summary>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		protected void WriteAttribute (string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			WriteAttributeTo (__razor_writer, name, prefix, suffix, values);
		}

		// This method is REQUIRED if the template contains any Razor helpers, but you may choose to implement it differently
		//
		/// <summary>
		/// Conditionally writes an attribute to a TextWriter.
		/// </summary>
		/// <param name="writer">The TextWriter to which to write the attribute.</param>
		/// <param name="name">The name of the attribute.</param>
		/// <param name="prefix">The prefix of the attribute.</param>
		/// <param name="suffix">The suffix of the attribute.</param>
		/// <param name="values">Attribute values, each specifying a prefix, value and whether it's a literal.</param>
		///<remarks>Used by Razor helpers to write attributes.</remarks>
		protected static void WriteAttributeTo (System.IO.TextWriter writer, string name, string prefix, string suffix, params Tuple<string,object,bool>[] values)
		{
			// this is based on System.Web.WebPages.WebPageExecutingBase
			// Copyright (c) Microsoft Open Technologies, Inc.
			// Licensed under the Apache License, Version 2.0
			if (values.Length == 0) {
				// Explicitly empty attribute, so write the prefix and suffix
				writer.Write (prefix);
				writer.Write (suffix);
				return;
			}

			bool first = true;
			bool wroteSomething = false;

			for (int i = 0; i < values.Length; i++) {
				Tuple<string,object,bool> attrVal = values [i];
				string attPrefix = attrVal.Item1;
				object value = attrVal.Item2;
				bool isLiteral = attrVal.Item3;

				if (value == null) {
					// Nothing to write
					continue;
				}

				// The special cases here are that the value we're writing might already be a string, or that the 
				// value might be a bool. If the value is the bool 'true' we want to write the attribute name instead
				// of the string 'true'. If the value is the bool 'false' we don't want to write anything.
				//
				// Otherwise the value is another object (perhaps an IHtmlString), and we'll ask it to format itself.
				string stringValue;
				bool? boolValue = value as bool?;
				if (boolValue == true) {
					stringValue = name;
				} else if (boolValue == false) {
					continue;
				} else {
					stringValue = value as string;
				}

				if (first) {
					writer.Write (prefix);
					first = false;
				} else {
					writer.Write (attPrefix);
				}

				if (isLiteral) {
					writer.Write (stringValue ?? value);
				} else {
					WriteTo (writer, stringValue ?? value);
				}
				wroteSomething = true;
			}
			if (wroteSomething) {
				writer.Write (suffix);
			}
		}
		// This method is REQUIRED. The generated Razor subclass will override it with the generated code.
		//
		///<summary>Executes the template, writing output to the Write and WriteLiteral methods.</summary>.
		///<remarks>Not intended to be called directly. Call the Generate method instead.</remarks>
		public abstract void Execute ();

}
}
#pragma warning restore 1591

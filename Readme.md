<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128597256/23.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E91)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Reporting for WinForms - How to Create a Custom Brick  

This example demonstrates how to inherit from existing Brick classes to create custom bricks.

The **HyperLinkBrick** brick inherits from the [TextBrick](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.TextBrick) class.

![HyperlinkBrick](Images/hyperlinkbrick.png)

The **EllipseBrick** brick inherits from the [Brick](https://docs.devexpress.com/CoreLibraries/DevExpress.XtraPrinting.Brick) class and requires a  `DevExpress.XtraPrinting.BrickExporters.BrickExporter` descendant that implements a method to draw a brick.

![EllipseBrick](Images/ellipsebrick.png)

## Files to Review

- [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
- [MyBrick.cs](./CS/MyBrick.cs) (VB: [MyBrick.vb](./VB/MyBrick.vb))

## Documentation

- [Bricks](https://docs.devexpress.com/WindowsForms/88/controls-and-libraries/printing-exporting/concepts/basic-terms/bricks)

## More Examples

- [How to use a custom BrickExporter](https://github.com/DevExpress-Examples/Reporting_how-to-use-custom-brickexporter-e2892)
- [How to scroll a document in the print preview to a specific page or brick](https://github.com/DevExpress-Examples/Reporting_how-to-scroll-a-document-in-the-print-preview-to-a-specific-page-or-brick-e2386)

<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-custom-brick&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=reporting-winforms-custom-brick&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

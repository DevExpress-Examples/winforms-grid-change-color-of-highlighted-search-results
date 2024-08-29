<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128626022/24.2.1%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3260)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WinForms Data Grid - Change the color of highlighted search results

This example demonstrates how to handle the [CustomDrawCell](https://docs.devexpress.com/WindowsForms/DevExpress.XtraGrid.Views.Grid.GridView.CustomDrawCell) event and paint the highlighted text that matches the search string specified in the grid's Find Panel:

```csharp
private void OnCustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e) {
    GridView view = sender as GridView;
    if (view.OptionsFind.HighlightFindResults && !view.FindFilterText.Equals(string.Empty)) {
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo cellInfo = ((DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)e.Cell);
        if (cellInfo != null && cellInfo.ViewInfo != null && cellInfo.ViewInfo.HasMatchedString) {
            e.Appearance.FillRectangle(e.Cache, e.Bounds);                     
            e.Cache.Paint.DrawMultiColorString(e.Cache, e.Bounds, e.DisplayText, cellInfo.ViewInfo.MatchedRanges,
            e.Appearance, e.Appearance.GetStringFormat(), Color.Indigo, Color.LightSlateGray, true);
            e.Handled = true;
        }
    }
}
```

Another technique to change background and foreground colors of search results is to customize corresponding skin properties. This allows you to change colors of highlighted text across the entire application. Read the following KB article for more information: [How to change one skin element in all available skins](https://www.devexpress.com/Support/Center/Question/Details/K18374).

```C#
var skin = CommonSkins.GetSkin(LookAndFeel);
skin.Colors[CommonColors.HighlightSearch] = Color.Red;
skin.Colors[CommonColors.HighlightSearchText] = Color.Blue;
```

```VB.NET
Dim skin = CommonSkins.GetSkin(LookAndFeel)
skin.Colors(CommonColors.HighlightSearch) = Color.Red
skin.Colors(CommonColors.HighlightSearchText) = Color.Blue
```

The following code demonstrates how to obtain these colors:

```C#
Color backColor = skin.Colors.GetColor(CommonColors.HighlightSearch);
Color foreColor = skin.Colors.GetColor(CommonColors.HighlightSearchText);
AppearanceDefault highlightAppearance = LookAndFeelHelper.GetHighlightSearchAppearance(LookAndFeel, true);
```

```VB.NET
Dim backColor As Color = skin.Colors.GetColor(CommonColors.HighlightSearch)
Dim foreColor As Color = skin.Colors.GetColor(CommonColors.HighlightSearchText)
Dim highlightAppearance As AppearanceDefault = LookAndFeelHelper.GetHighlightSearchAppearance(LookAndFeel, True)
```

> **Note**
>
> We recommend that you create a custom skin using our [Skin Editor](https://docs.devexpress.com/SkinEditor/2547/create-new-skins), as skin item names may change in newer versions.


## Files to Review

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-change-color-of-highlighted-search-results&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-grid-change-color-of-highlighted-search-results&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->

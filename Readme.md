<!-- default file list -->
*Files to look at*:

* [Main.cs](./CS/WindowsApplication3/Main.cs) (VB: [Main.vb](./VB/WindowsApplication3/Main.vb))
* [Program.cs](./CS/WindowsApplication3/Program.cs) (VB: [Program.vb](./VB/WindowsApplication3/Program.vb))
<!-- default file list end -->
# How to change colors of a highlighted text corresponding to a search string of Find Panel

The simplest way to change these colors is to modify the corresponding skin properties:

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

If it's necessary to obtain these colors, use the following code:
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

Using this approach you can change colors of a highlighted text application wide. See the [How to change one skin element in all available skins](https://www.devexpress.com/Support/Center/Question/Details/K18374) article for details.

Note, however, that we recommend that you create a custom skin using our Skin Editor tool. This approach is more stable since skin element names can be changed in future releases.


Alternatively, you can use custom painting to complete this task. This example illustrates how to customize foreground and background colors of a search string highlighted within located records in a grid using this approach. The main idea is to handle the CustomDrawCell event and use the ViewInfo.MatchedRanges property to paint the highlighted text.
<br/>

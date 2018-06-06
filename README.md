# Tab Control with Close Button
You can show close button on tab pages of a tab control to let the users close a tab.

To do so, We will use an owner draw tab to show close icons on each tab. We use `DrawItem` to draw close button, `MouseDown` to handle click on close button, and `HandleCreated` to adjust tab width.

You need to set a suitable padding and set `DrawMode` to `OwnerDrawFixed` and also set the text of last tab page to empty string. We will use that tab as add button. 

**Handle click on close button**

You can handle `MouseDown` or `MouseClick` event and check if the last tab rectangle contains the mouse clicked point, then insert a tab before the last tab. Otherwose check if one of close buttons contains clicked location, then close the tab which its close button was clicked

**Draw Close Button**

To draw close button, you can handle `DrawItem` event. 

**Adjust Tab width**

To adjust tab width, you can hanlde `HandleCreated` event and send a [`TCM_SETMINTABWIDTH `](https://msdn.microsoft.com/en-us/library/windows/desktop/bb760637(v=vs.85).aspx) to the control and specify the minimum size allowed for the tab width

**Enhancements**

You can enhance the implementation by using `VisualStyleRenderer` and also supporting different tab orientation and also adding rtl support.

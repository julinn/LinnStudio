使用方法：
1，引入js
<script language="javascript" type="text/javascript" src="./js/ulLinnDatePicker/WdatePicker.js"></script>

2，定义通用方法
public static void AddClickDate(WebControl ctl)
{
    ctl.Attributes.Add("onclick", "WdatePicker()");
}

3，调用方法
AddClickDate(TextBox1);
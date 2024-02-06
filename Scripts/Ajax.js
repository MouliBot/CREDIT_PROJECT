function DataJson(dept_json) {
    var dept_select = "<select id='dept'><option value=null>SELECT</option>";
    $.each(dept_json, function (IndexInArray, valueOfElement) {
        dept_select += "<option value='" + valueOfElement.DEPT_ID + "'>" + valueOfElement.DEPT_ID + "</option>"
    });
    dept_select += "</select>";
    // console.log(dept_select);
    $("#dept").html(dept_select);

}
$(document).ready(function () {
    $("#SubBtn").click(function () {
        // var name=$("#name").val();
        // var place=$("#place").val();
        // var data={"name":name,"place":place}
        var roleId1 = $("#roleId").val();
        var deptId1 = $("#dept").val();
        var roleName1 = $("#roleName").val();
        var data={"roleId":roleId1,"dept":deptId1,"roleName":roleName1}
        $.ajax({
            type: "post",
            url: "Ajax.aspx/InsertData",
            // data:"Req=1&name="+name+"&place="+place,
            // data:"roleId="+roleId1+"&dept="+deptId1+"&roleName="+roleName1,
            data:JSON.stringify(data),
            // data: "{}",
            // dataType:"text",
            // data: JSON.stringify(data),
            dataType: "json",
            // contentType:"application/x-www-form-urlencoded",
            contentType: "application/json",
            success: function (response) {
                alert(response.d);
                // var dept_json = JSON.parse(response.d);
                // DataJson(dept_json);
            },
            failure: function () {

            }

        });

    });
    $.ajax({
        type: "post",
        url: "Ajax.aspx/GetJsonData",
        // data:"Req=1&name="+name+"&place="+place,

        // data:JSON.stringify(data),
        data: "{}",
        // dataType:"text",
        dataType: "json",
        // contentType:"application/x-www-form-urlencoded",
        contentType: "application/json",
        success: function (response) {
            var dept_json = JSON.parse(response.d);
            DataJson(dept_json);
        },
        failure: function () {

        }

    });
});

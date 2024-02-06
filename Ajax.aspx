<%@ Page Language="C#" Inherits="CREDIT.Ajax" Debug="true" CodeFile="Businesslogic/Ajax.aspx.cs" %>
    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>AJAX</title>
        <script src="Scripts/jquery-3.5.1.js"></script>
        <script src="Scripts/Ajax.js"></script>
    </head>

    <body>
        <form>
            <table>
                <tr>
                    <td>Role ID:</td>
                    <td><input type="text" id="roleId"></td>
                </tr>
                <tr>
                    <td>DEPT ID:</td>
                    <td><span id="dept"></span></td>
                </tr>
                <tr>
                    <td>ROLE NAMES:</td>
                    <td><input type="text" id="roleName"></td>
                </tr>
            </table>
        </form>
        <button id="SubBtn">SUBMIT</button>
    </body>

    </html>
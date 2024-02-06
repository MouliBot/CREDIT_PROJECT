<%@ Page Language="C#" Inherits="CREDIT.CreditTransaction" Debug="true"
    CodeFile="Businesslogic/CreditTransaction.aspx.cs" %>
    <!DOCTYPE html>
    <html lang="en">

    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Credit Transaction | 2024</title>
        <style>
            .MainDiv{
                background-color: azure;
            }
        </style>
    </head>

    <body>
        <form runat="server">
            <div class="MainDiv">
                <h2>CREDIT TRANSACTION | 2023</h2>
                <table>
                    <tr>
                        <td><label>Credit Card Number: </label></td>
                        <td><input type="text" id="CreditNum" placeholder="Ex: 111111111111XXXX" runat="server"> <span
                                id="NumTxt"></span></td>
                    </tr>
                    <tr>
                        <td><label>Card Holder Name: </label></td>
                        <td><input type="text" id="CreditName" runat="server"> <span id="NameTxt"></span></td>
                    </tr>
                    <tr>
                        <td><label>Expiry Date:</label></td>
                        <td><input type="text" id="CreditDate" placeholder="YYYY-MM-DD" runat="server"> <span
                                id="DateTxt"></span></td>
                    </tr>
                    <tr>
                        <td><label>Enter CVV:</label></td>
                        <td><input type="text" id="CreditCvv" placeholder="Ex:XXX" runat="server"> <span
                                id="CvvTxt"></span></td>
                    </tr>
                    <tr>
                        <td><label>Enter Amount:</label></td>
                        <td><input type="text" id="CreditAmt" runat="server"> <span id="AmtTxt"></span></td>
                    </tr>
                    <tr>
                        <td><input type="submit" onclick="return CreditTransactionValidate()" runat="server"
                                onserverclick="Transact"></td>
                    </tr>
                </table>
            </div>
        </form>
        <script src="./Scripts/CreditTransaction.js"></script>

    </body>

    </html>
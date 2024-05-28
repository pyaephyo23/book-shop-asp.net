<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BookShop.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Css/bootstrap.min.css" />
</head>
<body style="background-color: #bed6c5">
    <div class="container-fluid">
        <div class="row mt-5 mb-5">
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                                <img src="../Images/open-book.png" width="100px" height="100px" />
                            </div>
                        </div>

                    </div>


                    <div class="mt-3">
                        <label for="" class="col-form-label">Email </label>
                        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <label for="" class="col-form-label">Password</label>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Text="Password" CssClass="form-control" ValidateRequestMode="Enabled"></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                    </div>
                    <div class="mt-3">
                        <asp:Button runat="server" Text="Login" CssClass="btn-success btn btn-block" ID="btnLogin" OnClick="btnLogin_Click" />
                    </div>
                </form>
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>
</body>
</html>

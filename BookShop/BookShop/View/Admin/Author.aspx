<%@ Page Title="" Language="C#" MasterPageFile="~/View/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="BookShop.View.Admin.Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MyContant" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <h3 class="text-center">Manage Authors
                </h3>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Author Name"></asp:Label>
                    <asp:TextBox ID="txtName" placeholder="Name" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="mb-3">
                    <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                    <asp:DropDownList ID="cboGender" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Country"></asp:Label>
                    <asp:DropDownList ID="cboCountry" runat="server" CssClass="form-control" AutoPostBack="True">
                        <asp:ListItem>Myanmar</asp:ListItem>
                        <asp:ListItem>United States</asp:ListItem>
                        <asp:ListItem>China</asp:ListItem>
                        <asp:ListItem>India</asp:ListItem>
                        <asp:ListItem>Indonesia</asp:ListItem>
                        <asp:ListItem>Pakistan</asp:ListItem>
                        <asp:ListItem>Brazil</asp:ListItem>
                        <asp:ListItem>Nigeria</asp:ListItem>
                        <asp:ListItem>Bangladesh</asp:ListItem>
                        <asp:ListItem>Russia</asp:ListItem>
                        <asp:ListItem>Mexico</asp:ListItem>
                        <asp:ListItem>Japan</asp:ListItem>
                        <asp:ListItem>Ethiopia</asp:ListItem>
                        <asp:ListItem>Philippines</asp:ListItem>
                        <asp:ListItem>Egypt</asp:ListItem>
                        <asp:ListItem>Vietnam</asp:ListItem>
                        <asp:ListItem>DR Congo</asp:ListItem>
                        <asp:ListItem>Iran</asp:ListItem>
                        <asp:ListItem>Turkey</asp:ListItem>
                        <asp:ListItem>Germany</asp:ListItem>
                        <asp:ListItem>Thailand</asp:ListItem>
                        <asp:ListItem>United Kingdom</asp:ListItem>
                        <asp:ListItem>France</asp:ListItem>
                        <asp:ListItem>Italy</asp:ListItem>
                        <asp:ListItem>Tanzania</asp:ListItem>
                        <asp:ListItem>South Africa</asp:ListItem>
                        <asp:ListItem>Kenya</asp:ListItem>
                        <asp:ListItem>South Korea</asp:ListItem>
                        <asp:ListItem>Colombia</asp:ListItem>
                        <asp:ListItem>Spain</asp:ListItem>
                        <asp:ListItem>Argentina</asp:ListItem>
                        <asp:ListItem>Algeria</asp:ListItem>
                        <asp:ListItem>Sudan</asp:ListItem>
                        <asp:ListItem>Ukraine</asp:ListItem>
                        <asp:ListItem>Uganda</asp:ListItem>
                        <asp:ListItem>Iraq</asp:ListItem>
                        <asp:ListItem>Poland</asp:ListItem>
                        <asp:ListItem>Canada</asp:ListItem>
                        <asp:ListItem>Morocco</asp:ListItem>
                        <asp:ListItem>Afghanistan</asp:ListItem>
                        <asp:ListItem>Saudi Arabia</asp:ListItem>
                        <asp:ListItem>Peru</asp:ListItem>
                        <asp:ListItem>Venezuela</asp:ListItem>
                        <asp:ListItem>Malaysia</asp:ListItem>
                        <asp:ListItem>Uzbekistan</asp:ListItem>
                        <asp:ListItem>Ghana</asp:ListItem>
                        <asp:ListItem>Yemen</asp:ListItem>
                        <asp:ListItem>Mozambique</asp:ListItem>
                        <asp:ListItem>Nepal</asp:ListItem>

                    </asp:DropDownList>

                </div>

                <div class="row">
                    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>
                </div>
                <div class="row mt-2">
                    <div class="d-block col">
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn-success btn-block btn" OnClick="btnSave_Click" />
                    </div>
                    <div class="d-block col">
                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn-success btn-block btn" OnClick="btnUpdate_Click" />
                    </div>

                    <div class="d-block col">
                        <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn-danger btn-block btn" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <div class="col-md-8" aria-atomic="True">
                <asp:GridView ID="dgvAuthor" runat="server" CssClass="table-bordered table" AutoGenerateSelectButton="True" OnSelectedIndexChanged="dgvAuthor_SelectedIndexChanged1" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="AuthorId" HeaderText="AuthorId" />
                        <asp:BoundField DataField="AuthorName" HeaderText="Author Name" />
                        <asp:BoundField DataField="AuthorGender" HeaderText="Author Gender" />
                        <asp:BoundField DataField="AuthorCountry" HeaderText="Author Country" />
                </Columns>
                    <SelectedRowStyle BackColor="#99FF99" ForeColor="Black" />
                </asp:GridView>
                
                    
            </div>
        </div>
    </div>
</asp:Content>

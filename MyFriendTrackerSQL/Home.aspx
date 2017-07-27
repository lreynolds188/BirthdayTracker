<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MyFriendTrackerSQL._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
                <table class="table table-striped">
                    <tr>
                        <td>
                            <asp:Label ID="Name" runat="server" Text="Name" Width="100px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control input-sm" Width="170px" Wrap="False"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="DateOfBirth" runat="server" Text="Date of Birth" Width="100px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDoB" runat="server" CssClass="form-control input-sm" Width="170px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Likes" runat="server" Text="Likes" Width="100px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtLikes" runat="server" CssClass="form-control input-sm" Width="170px"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Dislikes" runat="server" Text="Dislikes" Width="100px"></asp:Label></td>
                        <td>
                            <asp:TextBox ID="txtDislikes" runat="server" CssClass="form-control input-sm" Width="170px"></asp:TextBox></td>
                    </tr>
                </table>

    <br />

    <table class="table table-striped">
        <tr>
            <td>
                <asp:Button ID="btnNew" runat="server" Text="New" Width="70px" CssClass="btn btn-success" OnClick="btnNew_Click" /></td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" Width="70px" CssClass="btn btn-primary" OnClick="btnSave_Click" /></td>
            <td>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" Width="70px" CssClass="btn btn-danger" OnClick="btnDelete_Click" /></td>
        </tr>
    </table>

    <br />

    <table class="table table-striped">
        <tr>
            <td>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control input-sm" Width="148px"></asp:TextBox></td>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" /></td>
        </tr>
    </table>

    <br />

    <table class="table table-striped">
        <tr>
            <td>
                <asp:LinkButton ID="btnFirst" runat="server" CssClass="btn btn-default" OnClick="btnFirst_Click"><span class="glyphicon glyphicon-step-backward"></span></asp:LinkButton></td>
            <td>
                <asp:LinkButton ID="btnPrev" runat="server" CssClass="btn btn-default" OnClick="btnPrev_Click"><span class="glyphicon glyphicon-backward"></span></asp:LinkButton></td>
            <td>
                <asp:LinkButton ID="btnNext" runat="server" CssClass="btn btn-default" OnClick="btnNext_Click"><span class="glyphicon glyphicon-forward"></span></asp:LinkButton></td>
            <td>
                <asp:LinkButton ID="btnLast" runat="server" CssClass="btn btn-default" OnClick="btnLast_Click"><span class="glyphicon glyphicon-fast-forward"></span></asp:LinkButton></td>

        </tr>
    </table>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>

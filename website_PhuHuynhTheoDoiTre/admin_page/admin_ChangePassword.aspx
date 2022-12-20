<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_ChangePassword.aspx.cs" Inherits="website_PhuHuynhTheoDoiTre_admin_page_admin_ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <script>
        function checkNULL() {
            var mkcu = document.getElementById("<%= txtMatKhauCu.ClientID%>");
            var mkmoi = document.getElementById("<%= txtMatKhauMoi.ClientID%>");
            var mkxc = document.getElementById("<%= txtNhapLai.ClientID%>");
           
            if (mkcu.value.trim() == "" || mkmoi.value.trim() == "" || mkxc.value.trim() == "") {
                alert(mkcu.value.trim());
                swal('Vui lòng nhập đầy đủ thông tin!', '', 'warning').then(function () { mkcu.focus(); });
                return false;
            }
            
            return true;
        }
    </script>
    <div class="card card-block">
        <h3 style="text-align: center">ĐỔI MẬT KHẨU</h3>
        <%--<div class="form-group row">
            <label class="col-sm-3 form-control-label">Email nhận lại mật khẩu:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>--%>
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Mật khẩu hiện tại:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtMatKhauCu" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Mật khẩu mới:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtMatKhauMoi" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <label class="col-sm-3 form-control-label">Xác nhận mật khẩu mới:</label>
            <div class="col-sm-5">
                <asp:TextBox ID="txtNhapLai" TextMode="Password" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
            </div>
        </div>
        <div class="form-group row">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="col-sm-10">
                        <a href="#" runat="server" id="btnLuu" onclick="return checkNULL()" onserverclick="btnLuu_Click">Xác nhận</a>
                        <%--<a href="#" ID="btnLuu" runat="server"  CssClass="btn btn-primary" OnClientClick="return checkNULL()" ons="btnLuu_Click" >Xác nhân</a>--%>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


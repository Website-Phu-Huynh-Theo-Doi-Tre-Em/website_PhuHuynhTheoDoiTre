<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_UserManage.aspx.cs" Inherits="admin_page_module_access_admin_UserManage" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <style>
        .field-icon {
            float: right;
            margin-left: -25px;
            margin-top: -25px;
            position: relative;
            z-index: 2;
        }
    </style>
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
            popupControl.Hide();
        }
        function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }
        function checkNULL() {
            var fullName = document.getElementById('<%= txtFullname.ClientID%>');
            var taiKhoan = document.getElementById('<%= txtUserName.ClientID%>');
            var matKhau = document.getElementById('<%= txtPass.ClientID%>');
            var coso = document.getElementById('<%= ddlCoSo.ClientID%>');
            if (fullName.value.trim() == "") {
                swal('Họ tên không được để trống!', '', 'warning').then(function () { fullName.focus(); });
                return false;
            }
            if (taiKhoan.value.trim() == "") {
                swal('Tên tài khoản không được để trống!', '', 'warning').then(function () { taiKhoan.focus(); });
                return false;
            }
            if (matKhau.value.trim() == "") {
                swal('Mật khẩu không được để trống!', '', 'warning').then(function () { document.getElementById("txtpassword").focus(); });
                return false;
            }
            //if (coso.value == "0") {
            //    swal('Vui lòng chọn cơ sở!', '', 'warning').then(function () { coso.focus(); });
            //    return false;
            //}
            return true;
        }
        function confirmDel() {
            swal("Bạn có thực sự muốn xóa?",
                "Nếu xóa, dữ liệu sẽ không thể khôi phục.",
                "warning",
                {
                    buttons: true,
                    dangerMode: true
                }).then(function (value) {
                    if (value == true) {
                        var xoa = document.getElementById('<%=btnXoa.ClientID%>');
                        xoa.click();
                    }
                });
        }
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false; return true;
        };
        function showPassWord() {
            var x = document.getElementById("txtpassword");
            if (x.type === "password") {
                x.type = "text";
                document.getElementById("lbShow").innerHTML = "Ẩn";
            } else {
                x.type = "password";
                document.getElementById("lbShow").innerHTML = "Hiển thị";
            }
        }
        function setPasswod() {
            var values = document.getElementById("txtpassword").value;
            document.getElementById('<%= txtPass.ClientID%>').value = values;
        }
        function disabledInput() {
            //document.getElementById("txtpassword").setAttribute("disabled", "disabled");

        }
    </script>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-10" id="div_Button" runat="server">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary " OnClick="btnThem_Click" />
                        <asp:Button ID="btnChiTiet" runat="server" Text="Chi tiết" CssClass="btn btn-primary" OnClick="btnChiTiet_Click" />
                        <input type="submit" class="btn btn-primary " value="Xóa" onclick="confirmDel()" />
                        <asp:Button ID="btnXoa" runat="server" CssClass="invisible" OnClick="btnXoa_Click" />
                        <a href="#" id="btnImportExcel" class="btn btn-primary" data-toggle="modal" data-target="#modal_ImportExcel" style="display:none">Nhập Excel</a>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <a href="/admin-quan-ly-he-thong-tai-khoan" class="btn btn-primary float-sm-right">Quay lại</a>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="username_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="2%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Tài khoản" FieldName="username_username" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Họ tên" FieldName="username_fullname" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Email" FieldName="username_email" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Số điện thoại" FieldName="username_phone" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Cơ sở" FieldName="coso_name" HeaderStyle-HorizontalAlign="Center" Width="10%">
                    </dx:GridViewDataColumn>
                </Columns>
                <ClientSideEvents RowDblClick="btnChiTiet" />
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="600px" Height="450px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="ĐĂNG KÝ THÔNG TIN TÀI KHOẢN" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12">
                                    <div class="col-12">
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Tài khoản *:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtUserName" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Mật khẩu *:</label>
                                            <div class="col-10">
                                                <div style="display: flex">
                                                    <input type="password" name="name" id="txtpassword" class="form-control" style="width: 80%" onchange="setPasswod()" />
                                                    <span onclick="showPassWord()" style="padding: 11px 0 9px 5px; color: #007ae5;" id="lbShow">Hiển thị</span>
                                                </div>
                                                <input type="text" id="txtPass" runat="server" class="form-control" style="width: 95%; display: none" />
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Họ tên:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtFullname" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Số điện thoại:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtPhone" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%" onkeypress="return isNumberKey(event)"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Email:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group">
                                            <label class="col-2 form-control-label">Địa chỉ:</label>
                                            <div class="col-10">
                                                <asp:TextBox ID="txtDiaChi" runat="server" ClientIDMode="Static" CssClass="form-control boxed" Width="95%"> </asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-12 form-group" style="display: none">
                                            <label class="col-2 form-control-label">Cơ sở:</label>
                                            <div class="col-10">
                                                <asp:DropDownList runat="server" ID="ddlCoSo" class=" form-control form-select_class" Width="90%">
                                                    <asp:ListItem Value="0" Text="Chọn cơ sở" />
                                                    <asp:ListItem Value="1" Text="Cơ sở 1" />
                                                    <asp:ListItem Value="2" Text="Cơ sở 2" />
                                                    <asp:ListItem Value="3" Text="Cơ sở 3" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <div class="mar_but button">
                <asp:Button ID="btnLuu" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuu_Click" />
            </div>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
    <%--modal import excel--%>
    <div class="modal fade" id="modal_ImportExcel" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <span class="title_modal">Import excel
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </span>
                </div>
                <div class="modal-body">
                    <asp:FileUpload ID="fuUpload" multiple="multiple" runat="server" accept=".xls,.xlsx" />
                    <div>
                        <span>Nếu chưa có mẫu file vui lòng download <a href="../../../Excel Files/Mẫu form thông tin học sinh.xlsx" download style="color: #0275d8">tại đây</a></span>
                    </div>
                </div>
                <div class="modal-footer">
                    <a href="#" class="btn btn-primary" id="btnImport" runat="server" onserverclick="btnImport_ServerClick">Lưu</a>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


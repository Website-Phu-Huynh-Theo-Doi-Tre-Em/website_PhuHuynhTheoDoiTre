<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DanhSachKhongDangKyChuongTrinhNgoaiKhoa.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_DanhSachKhongDangKyChuongTrinhNgoaiKhoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">

    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
            popupControl.Hide();
        }
        <%--function btnChiTiet() {
            document.getElementById('<%=btnChiTiet.ClientID%>').click();
        }--%>
        function popupHide() {
            document.getElementById('btnClosePopup').click();
        }
    </script>
     <script>
         function DisplayLoadingIcon() {
             $("#img-loading-icon").show();
         }
         function HiddenLoadingIcon() {
             $("#img-loading-icon").hide();
         }
     </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="card card-block">
        <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">DANH SÁCH KHÔNG ĐĂNG KÝ NGOẠI KHÓA</h3>
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server" Visible="true">
                    <ContentTemplate>
                        <asp:Button ID="btnXacNhan" runat="server" Text="Xác nhận" CssClass="btn btn-primary" OnClientClick="DisplayLoadingIcon()" OnClick="btnXacNhan_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <a href="#" class="btn btn-primary" id="btnXuatExcel" runat="server" onserverclick="btnXuatExcel_ServerClick">Xuất excel</a>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="dangkyngoaikhoa_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%"></dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Học sinh" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Lớp" FieldName="lop_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Chương trình đăng ký" FieldName="ngoaikhoa_name" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày đăng ký" FieldName="dangkyngoaikhoa_datecreate" HeaderStyle-HorizontalAlign="Center" Width="10%" Settings-AllowEllipsisInText="True"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Năm học" FieldName="namhoc_nienkhoa" HeaderStyle-HorizontalAlign="Center" Width="8%" Settings-AllowEllipsisInText="True"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Trạng thái" FieldName="tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="8%" Settings-AllowEllipsisInText="True"></dx:GridViewDataColumn>
                </Columns>
                <%--<ClientSideEvents RowDblClick="btnChiTiet" />--%>
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" Runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" Runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" Runat="Server">
</asp:Content>


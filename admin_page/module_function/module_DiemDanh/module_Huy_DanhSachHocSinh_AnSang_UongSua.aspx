<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_Huy_DanhSachHocSinh_AnSang_UongSua.aspx.cs" Inherits="admin_page_module_function_module_DiemDanh_module_Huy_DanhSachHocSinh_AnSang_UongSua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">
     <script type="text/javascript">
        function func() {
            grvList.Refresh();
        }
     </script>
    <div class="card card-block">
        <div>
                <a href="/admin-danh-sach-huy-dang-ky-an-sang" class="btn btn-primary">Quay lại</a>
            </div>
         <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">HỦY ĐĂNG KÍ ĂN SÁNG UỐNG SỮA</h3>
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:Button ID="btnHuyAnSang" runat="server" OnClick="btnHuyAnSang_Click" Text="Hủy ăn sáng" CssClass="btn btn-primary" />
                <asp:Button ID="btnHuyUongSua" runat="server" OnClick="btnHuyUongSua_Click" Text="Hủy uống sữa" CssClass="btn btn-primary" />
                <asp:Button ID="btnHuyAnSangUongSua" runat="server" OnClick="btnHuyAnSangUongSua_Click" Text="Hủy ăn sáng và uống sữa" CssClass="btn btn-primary" />
                 Ngày bắt đầu
                <input id="dteNgayBatDau" type="date" runat="server" />
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="ansang_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Lớp" FieldName="lop_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Học sinh" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày bắt đầu" FieldName="ansang_datecreate" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có ăn sáng" FieldName="ansang_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có uống sữa" FieldName="uongsua_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                </Columns>
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Trống" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
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


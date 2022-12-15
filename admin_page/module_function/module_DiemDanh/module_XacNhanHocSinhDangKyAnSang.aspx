<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_XacNhanHocSinhDangKyAnSang.aspx.cs" Inherits="admin_page_module_function_module_DiemDanh_module_XacNhanHocSinhDangKyAnSang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" Runat="Server">
     <style>
          .modal-dialog {
            max-width: 64rem;
            margin: 4% auto;
        }

    </style>
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
        }
       <%-- function confirmDel() {
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
        }--%>
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
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
        <h3 style="text-align: center; font-size: 28px; font-weight: bold; color: blue">DANH SÁCH ĐĂNG KÍ ĂN SÁNG UỐNG SỮA</h3>
        <div class="form-group row">
            <div class="col-sm-10">
                <%--<asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>--%>
                <asp:Button ID="btnXacNhan" runat="server" OnClientClick="DisplayLoadingIcon()" OnClick="btnXacNhan_Click" Text="Xác nhận" CssClass="btn btn-primary" />
                <a href="#" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">File hướng dẫn</a>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
         <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <embed src="../../../file_huongdan/dang_ki_an_sang.pdf" width="1030" height="650" type="application/pdf" />
                    </div>
                </div>
            </div>
        </div>
        <div style="color: blue; font-size: 18px">
            Tổng số lượng học sinh đăng ký ăn sáng :
            <asp:Label ID="lblTongHocSinh" runat="server"></asp:Label>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="ansang_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Lớp" FieldName="lop_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Học sinh" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="30%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày đăng ký" FieldName="ansang_datecreate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tháng đăng ký" FieldName="ansang_thangdangky" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có ăn sáng" FieldName="ansang_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có uống sữa" FieldName="uongsua_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Trạng thái" FieldName="tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
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


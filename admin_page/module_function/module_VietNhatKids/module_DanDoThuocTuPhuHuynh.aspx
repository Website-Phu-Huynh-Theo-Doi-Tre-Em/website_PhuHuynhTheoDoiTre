<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_DanDoThuocTuPhuHuynh.aspx.cs" Inherits="admin_page_module_function_module_WebSite_module_DanDoThuocTuPhuHuynh" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v17.1" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <script type="text/javascript">
        function func() {
            grvList.Refresh();
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
    <style>
        .main-omt {
            border: 1px solid #32c5d2;
            background-color: #fff;
        }

            .main-omt .omt-header {
                background-color: #32c5d2;
                padding: 4px 7px;
                display: flex;
            }

        .omt-header .header-title {
            padding: 10px 10px;
            color: white;
        }

        .omt-header .omt__icon {
            font-size: 35px;
            padding: 5px 10px;
            color: white;
        }

        a.hocsinh__active {
            color: #ffffff !important;
            background-color: #FF4444 !important;
            border-color: #FF4444 !important;
        }

        .button__disable {
            cursor: not-allowed;
            pointer-events: none;
        }
        .modal-body {
    padding: unset;
}
        .modal-dialog {
            max-width: 64rem;
    margin: 4% auto;
        }
        .fade.in {
    background: #80808059;
    opacity: 1;
}
        .modal .modal-content {
    border-radius: 0;
    background: unset;
    border: none;
}
    </style>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="card card-block">
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnXacNhan" runat="server" Text="Xác nhận" CssClass="btn btn-primary" OnClientClick="DisplayLoadingIcon()" OnClick="btnXacNhan_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div style="text-align:right">
            <a href="#" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">File hướng dẫn</a>
            <a href="/admin-home" class="btn btn-primary">Quay lại</a>
        </div>
        <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-body">
                        <embed src="../../../file_huongdan/dan_thuoc_tu_phu_huynh.pdf" width="1030" height="650" type="application/pdf" />
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="phuhuynhdandothuoc_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%">
                    </dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="Học sinh" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Bệnh" FieldName="phuhuynhdandothuoc_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày đầu" FieldName="phuhuynhdandothuoc_createdate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày cuối" FieldName="phuhuynhdandothuoc_enddate" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Dặn dò từ phụ huynh" FieldName="phuhuynhdandothuoc_content" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tình trạng" FieldName="phuhuynhdandothuoc_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="8%"></dx:GridViewDataColumn>
                </Columns>
                <%--  <ClientSideEvents RowDblClick="btnChiTiet" />--%>
                <%--<SettingsSearchPanel Visible="true" />--%>
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


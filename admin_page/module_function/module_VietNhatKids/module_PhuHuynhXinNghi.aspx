<%@ Page Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_PhuHuynhXinNghi.aspx.cs" Inherits="admin_page_module_function_module_WebSite_module_PhuHuynhXinNghi" %>

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
        function checkNULL() {
            var CityName = document.getElementById('<%= dteTuNgay.ClientID%>');
            if (CityName.value.trim() == "") {
                swal('Ngày xin nghỉ không được để trống!', '', 'warning');
                return false;
            }
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
        <div class="form-group row">
            <div class="col-sm-10">
                <asp:UpdatePanel ID="udButton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary" OnClick="btnThemMoi_Click" />
                        <asp:Button ID="btnXacNhan" runat="server" Text="Xác nhận" CssClass="btn btn-primary" OnClientClick="DisplayLoadingIcon();" OnClick="btnXacNhan_Click" />
                        <asp:Button ID="btnCapNhatNgayNghi" runat="server" Text="Cập nhật ngày nghỉ" CssClass="btn btn-primary" OnClick="btnCapNhatNgayNghi_Click" />
                        <a href="#" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">File hướng dẫn</a>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
          <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <embed src="../../../file_huongdan/xin_nghi_tu_phu_huynh.pdf" width="1000" height="650" type="application/pdf" />
                </div>
            </div>
        </div>
    </div>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="phuhuynhxinnghi_id" Width="100%">
                <Columns>
                    <dx:GridViewCommandColumn ShowSelectCheckbox="True" SelectAllCheckboxMode="Page" VisibleIndex="0" Width="5%"></dx:GridViewCommandColumn>
                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                        <DataItemTemplate>
                            <%#Container.ItemIndex+1 %>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Học sinh" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày bắt đầu" FieldName="phuhuynhxinnghi_datestart" HeaderStyle-HorizontalAlign="Center" Width="20%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày kết thúc" FieldName="phuhuynhxinnghi_dateend" HeaderStyle-HorizontalAlign="Center" Width="20%" ></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày đăng kí" FieldName="phuhuynhxinnghi_ngaydangki" HeaderStyle-HorizontalAlign="Center" Width="20%" ></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Nội dung" FieldName="phuhuynhxinnghi_content" HeaderStyle-HorizontalAlign="Center" Width="30%" Settings-AllowEllipsisInText="True"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Xác nhận" FieldName="phuhuynhxinnghi_xacnhan" HeaderStyle-HorizontalAlign="Center" Width="30%" Settings-AllowEllipsisInText="True"></dx:GridViewDataColumn>
                </Columns>
                <%--<SettingsSearchPanel Visible="true" />--%>
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="20" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>

    </div>
    <dx:ASPxPopupControl ID="popupControl" runat="server" Width="800px" Height="400px" CloseAction="CloseButton" ShowCollapseButton="True" ShowMaximizeButton="True" ScrollBars="Auto" CloseOnEscape="true" Modal="True"
        PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ClientInstanceName="popupControl" ShowFooter="true"
        HeaderText="Xin nghỉ" AllowDragging="True" PopupAnimationType="Fade" EnableViewState="False" AutoUpdatePosition="true" ClientSideEvents-CloseUp="function(s,e){grvList.Refresh();}">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <asp:UpdatePanel ID="udPopup" runat="server">
                    <ContentTemplate>
                        <div class="popup-main">
                            <div class="div_content col-12">
                                <div class="col-12" runat="server" id="div_CapNhat">
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Họ tên bé:</label>
                                        <div class="col-10">
                                            <asp:Label Text="" ID="txtHoTen" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Ngày bắt đầu:</label>
                                        <div class="col-10">
                                            <input type="date" id="txtTuNgay" runat="server" class="form-control" style="width: 90%" />
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Ngày kết thúc:</label>
                                        <div class="col-10">
                                            <input type="date" id="txtDenNgay" runat="server" class="form-control" style="width: 90%" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12" runat="server" id="div_ThemMoi">
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Học sinh:</label>
                                        <div class="col-10">
                                            <dx:ASPxComboBox ID="ddlHocSinh" runat="server" ValueType="System.Int32" TextField="hocsinh_name" ValueField="hocsinh_id" ClientInstanceName="ddlHocSinh" CssClass="" Width="90%"></dx:ASPxComboBox>
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Ngày bắt đầu:</label>
                                        <div class="col-10">
                                            <input type="date" id="dteTuNgay" runat="server" class="form-control" style="width: 90%" />
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Ngày kết thúc:</label>
                                        <div class="col-10">
                                            <input type="date" id="dteDenNgay" runat="server" class="form-control" style="width: 90%" />
                                        </div>
                                    </div>
                                    <div class="col-12 form-group">
                                        <label class="col-2 form-control-label">Lý do:</label>
                                        <div class="col-10">
                                            <textarea id="txtLyDo" runat="server" style="width: 90%" rows="3"></textarea>
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
                <asp:Button ID="btnLuuThemMoi" runat="server" ClientIDMode="Static" Text="Lưu" CssClass="btn btn-primary" OnClientClick="return checkNULL()" OnClick="btnLuuThemMoi_Click" />
            </div>
        </FooterContentTemplate>
        <ContentStyle>
            <Paddings PaddingBottom="0px" />
        </ContentStyle>
    </dx:ASPxPopupControl>
  
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


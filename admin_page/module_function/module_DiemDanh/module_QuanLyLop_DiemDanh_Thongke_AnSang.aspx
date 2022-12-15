<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_QuanLyLop_DiemDanh_Thongke_AnSang.aspx.cs" Inherits="admin_page_module_function_module_HocTap_module_QuanLyLop_DiemDanh_Thongke_AnSang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="hihead" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="himenu" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="hibodyhead" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="hibodywrapper" runat="Server">
    <div class="main-omt">
        <div class="omt-header">
            <i class="fa fa-user omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">Thống kê ăn sáng, uống sữa</h4>
        </div>
        <div>
            <div class=" container form-group mt-2">
                <div class="col-6">
                    <p>
                        Tổng số học sinh đăng ký hiện tại:
                        <strong>
                            <asp:Label ID="lblTongDangKi" runat="server"></asp:Label></strong>
                        <a href="#" id="btnXemDangKi" runat="server" class="btn btn-primary btn__search" onserverclick="btnXemDangKi_ServerClick">Xem</a>
                    </p>
                    <p>
                        Tổng số học sinh hủy đăng ký hiện tại:
                    <strong>
                        <asp:Label ID="lblTongHuyDangKi" runat="server"></asp:Label></strong>
                        <a href="#" id="btnXemHuyDangKi" runat="server" class="btn btn-primary btn__search" onserverclick="btnXemHuyDangKi_ServerClick">Xem</a>
                    </p>
                </div>
            </div>
        </div>
        <strong style="text-align: center; font-size: 28px;">
            <asp:Label ID="lblDanhSach" runat="server"></asp:Label></strong>
        <div class="form-group table-responsive">
            <dx:ASPxGridView ID="grvList" runat="server" ClientInstanceName="grvList" KeyFieldName="ansang_id" Width="100%">
                <Columns>
                    <dx:GridViewDataColumn Caption="STT" HeaderStyle-HorizontalAlign="Center" Width="5%">
                        <DataItemTemplate>
                            <%#Container.ItemIndex+1 %>
                        </DataItemTemplate>
                    </dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Lớp" FieldName="lop_name" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Họ và tên" FieldName="hocsinh_name" HeaderStyle-HorizontalAlign="Center" Width="15%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Ngày đăng ký" FieldName="ngay" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Tháng bắt đầu" FieldName="thang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có ăn sáng" FieldName="ansang_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Có uống sữa" FieldName="uongsua_tinhtrang" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                    <dx:GridViewDataColumn Caption="Trạng thái" FieldName="trangthai" HeaderStyle-HorizontalAlign="Center" Width="10%"></dx:GridViewDataColumn>
                </Columns>
                <SettingsSearchPanel Visible="true" />
                <SettingsBehavior AllowFocusedRow="true" />
                <SettingsText EmptyDataRow="Không có dữ liệu" SearchPanelEditorNullText="Gỏ từ cần tìm kiếm và enter..." />
                <SettingsLoadingPanel Text="Đang tải..." />
                <SettingsPager PageSize="10" Summary-Text="Trang {0} / {1} ({2} trang)"></SettingsPager>
            </dx:ASPxGridView>
        </div>
        <%--<div class="table-omt omt-title-bot">
            <table class="table table-bordered">
                <thead class="thead-omt">
                    <tr>
                        <th scope="col">#</th>
                        <th scope="col">Lớp</th>
                        <th scope="col">Họ và Tên</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpLop" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th><%=STT++ %></th>
                                <td><%#Eval("lop_name") %></td>
                                <td><%#Eval("hocsinh_name") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                </tbody>
            </table>
        </div>--%>
    </div>
    <style>
        .main-omt {
            border: 1px solid #32c5d2;
            background-color: #fff;
        }

        .omt-header-khoi {
            border: 1px solid #808080;
            margin-top: 20px;
        }

        .omt-header-khoi-content {
            margin-left: 15px;
        }

        .omt_textSearch {
            display: block;
            width: 70%;
            padding: 0.5rem 0.75rem;
            font-size: 1rem;
            line-height: 1.25;
            color: #55595c;
            background-color: #fff;
            background-image: none;
            -webkit-background-clip: padding-box;
            background-clip: padding-box;
            border: 1px solid rgba(0, 0, 0, 0.15);
            border-radius: 0.25rem;
        }

        .omt-header-title {
            font-size: 16px;
            font-weight: bold;
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

        .omt-top {
            display: flex;
            padding: 0 20px;
        }

        .form-omt {
            width: 10%;
            height: 38px;
            margin-right: 15px;
            margin-top: 10px;
        }

        .form-group__omt {
            margin-top: 10px;
            width: 35%;
        }

        .omt-title-top {
            padding: 20px;
            background-color: #fbe1e3;
            margin: 0 20px;
            border-radius: 2px;
        }

            .omt-title-top .omt-title-top-title {
                font-size: 12px;
                color: #e73d4a;
                font-weight: 600;
            }

            .omt-title-top .omt-title-top-p {
                font-size: 12px;
                color: #e73d4a;
            }

        .omt-title-bot {
            padding: 20px;
            /*background-color: #faeaa9;*/
            margin: 15px 20px;
            border-radius: 2px;
        }

            .omt-title-bot .omt-title-top-p {
                margin: 0;
                font-size: 12px;
                font-weight: 600;
            }

        .header-th {
            width: 25px;
        }

        .thead-omt {
            background-color: #3598dc;
            color: white;
            text-align: center;
        }

        .table thead th {
            vertical-align: middle;
        }

        .table-omt__icon {
            font-size: 50px;
            padding-left: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


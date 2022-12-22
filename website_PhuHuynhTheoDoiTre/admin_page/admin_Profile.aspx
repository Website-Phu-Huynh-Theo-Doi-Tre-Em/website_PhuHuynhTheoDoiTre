<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_Profile.aspx.cs" Inherits="website_PhuHuynhTheoDoiTre_admin_page_admin_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headlink" runat="Server">
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

        .omt-top {
            display: flex;
            padding: 20px 20px;
        }

        .block-left {
            border: 1px solid #32c5d2;
            margin: 5px;
            -webkit-box-shadow: 7px 7px 5px 0px rgba(50, 50, 50, 0.75);
            -moz-box-shadow: 7px 7px 5px 0px rgba(50, 50, 50, 0.75);
            box-shadow: 7px 7px 5px 0px rgba(50, 50, 50, 0.75);
        }

        .khoi {
            margin-top: 15px;
        }

        .form-control-nhap {
            margin-left: 20px;
            width: 93%;
            display: block;
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

        .auto-style1 {
            width: 813px;
            margin-left: 38px;
        }

        .luu {
            margin: 10px;
        }
    </style>
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
            <i class="fa fa-list omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">Thông tin cá nhân</h4>
        </div>
        <div class="omt-top2">
            <%--  <div class="col-12" style="text-align:center">TRƯỜNG LIÊN CẤP VIỆT NHẬT NĂM 2020 - 2021</div>--%>
            <div class="col-12">
                <div class="block-left">
                    <div class="col-12">
                        <div class="col-4 float-lg-left">
                            <img src="#" style="width: 190px; height: 210px; margin-top: 10px; margin-left: 20px;" />
                            <input id="txtid" runat="server" type="text" style="width: 90%; margin-left: 20px;" class="form-control" />
                        </div>
                        <div class="col-8 float-lg-right">
                            <div class="col-8 float-lg-left">
                                <div class="khoi">
                                    <label class="form-check-label">Họ tên: </label>
                                    <input id="txtHoTen" runat="server" type="text" style="width: 90%; margin-left: 20px;" class="form-control" />
                                </div>
                            </div>
                            <div class="col-4 float-lg-right">
                                <div class="khoi">
                                    <label class="form-check-label">Giới tính: </label>
                                    <select class="form-control" id="ddlGioiTinh" runat="server" style="width: 82%; margin-left: 20px; margin-bottom: 15px; margin-left: 10px;">
                                        <option value="Nam">Nam</option>
                                        <option value="Nữ">Nữ</option>
                                    </select>
                                </div>
                            </div>

                            <div class="khoi">
                                <label class="form-check-label">Số điện thoại: </label>
                                <input id="txtSoDienThoai" runat="server" type="text" class="form-control-nhap" />
                            </div>
                            <div class="khoi">
                                <label class="form-check-label">Email: </label>
                                <input id="txtEmail" runat="server" type="text" class="form-control-nhap" />
                            </div>
                            <div class="khoi">
                                <label class="form-check-label">Chổ ở hiện tại: </label>
                                <input id="txtChoOHienTai" runat="server" type="text" class="form-control-nhap" />
                            </div>
                        </div>
                    </div>


                </div>
            </div>
            <div class="col-12">
            </div>
        </div>
        <div style="text-align: center">
            <a href="javascript:void(0);" id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick" class="luu btn btn-primary">Lưu</a>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>



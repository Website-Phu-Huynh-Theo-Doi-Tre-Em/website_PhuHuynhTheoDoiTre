<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="admin_Profile.aspx.cs" Inherits="admin_page_module_access_admin_Profile" %>

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
        <div class="omt-top">
            <%--  <div class="col-12" style="text-align:center">TRƯỜNG LIÊN CẤP VIỆT NHẬT NĂM 2020 - 2021</div>--%>
            <div class="col-12">
                <div class="block-left">
                    <div class="col-4">
                       
                        <img src="<%=img_src %>" style="width: 190px; height: 210px; margin-top: 10px;" />
                    </div>
                    <div class="col-8">
                        <div class="khoi">
                            <label class="form-check-label">Ông bà: </label>
                            <select class="form-control" id="ddlOngBa" runat="server" style="width: 90%; margin-left: 20px;">
                                <option value="Ông">Ông</option>
                                <option value="Bà">Bà</option>
                            </select>
                        </div>
                        <div class="khoi">
                            <label class="form-check-label">Họ tên: </label>
                            <input id="txtHoTen" runat="server" type="text" style="width: 90%; margin-left: 20px;" class="form-control" />
                        </div>
                        <div class="khoi">
                            <label class="form-check-label">Giới tính: </label>
                            <select class="form-control" id="ddlGioiTinh" runat="server" style="width: 90%; margin-left: 20px;  margin-bottom: 15px;">
                                <option value="Nam">Nam</option>
                                <option value="Nữ">Nữ</option>
                            </select>
                        </div>
                       
                    </div>
                     <div class="khoi">
                            <label class="form-check-label">Ngày sinh: </label>
                            <input id="dteNgaySinh" runat="server" type="date" style="margin-left: 20px;" class="form-control-nhap" />
                        </div>
                    <div class="khoi">
                        <label class="form-check-label">Nơi sinh (Xã/ Phường, Quận/ Huyện, Tỉnh/ Thành Phố): </label>
                        <input id="txtNoiSinh" runat="server" type="text" class="form-control-nhap" />
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
                    <div class="khoi" >
                        <label class="form-check-label">Địa chỉ thường trú: </label>
                        <input id="txtDiaChiThuowngTru" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi" style="margin-bottom: 18px">
                        <label class="form-check-label">Quốc tịch: </label>
                        <input id="txtQuocTich" runat="server" type="text" class="form-control-nhap" />
                    </div>
                </div>
            </div>
            <div class="col-12">
                <div class="block-left">
                    
                    <div class="khoi">
                        <label class="form-check-label">CMND: </label>
                        <input id="txtCMND" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">Ngày cấp: </label>
                        <input id="dteNgaycap" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">Nơi cấp: </label>
                        <input id="txtNoiCap" runat="server" type="text" class="form-control-nhap" />
                    </div>

                    <div class="khoi">
                        <label class="form-check-label">Chức vụ: </label>
                        <input id="txtChucVu" runat="server" type="text" class="form-control-nhap" />
                    </div>

                    <div class="khoi">
                        <label class="form-check-label">Bộ phận: </label>
                        <input id="txtBoPhan" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">trình độ: </label>
                        <input id="txtTrinhDo" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">Bằng cấp chuyên môn: </label>
                        <input id="txtBangCapChuyenMon" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">Nơi đào tạo: </label>
                        <input id="txtNoiDaoTao" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi">
                        <label class="form-check-label">Bằng cấp khác: </label>
                        <input id="txtBangCapKhac" runat="server" type="text" class="form-control-nhap" />
                    </div>
                    <div class="khoi" style="margin-bottom: 20px;">
                        <label class="form-check-label">Trình độ tiếng anh: </label>
                        <input id="txtTrinhDoTiengAnh" runat="server" type="text" class="form-control-nhap" />
                    </div>
                </div>
            </div>
        </div>
        <div style="text-align:center">
            <a href="javascript:void(0);" id="btnLuu" runat="server" onserverclick="btnLuu_ServerClick" class="btn btn-primary">Lưu</a>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_NhanXetBeAnHomNay.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_NhanXetBeAnHomNay" %>

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
        function myBuaChinh(value, id) {
            document.getElementById("txtbuachinh" + id).value = value;
        }
        function myBuaPhu(value, id) {
            document.getElementById("txtbuaphu" + id).value = value;
        }
        function setChecked() {
            var arr_ID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value.split(';');
            if (arr_ID != "") {
                for (var i = 0; i < arr_ID.length; i++) {
                    var _buachinh = document.getElementById("txtbuachinh" + arr_ID[i]).value;
                    var _buaphu = document.getElementById("txtbuaphu" + arr_ID[i]).value;
                    if (_buachinh != "") {
                        $('input[name="buachinh' + arr_ID[i] + '"][value="' + _buachinh + '"]').attr('checked', true);
                    }
                    else {
                        $('input[name="buachinh' + arr_ID[i] + '"][value="Bé ăn hết bữa chính. "]').attr('checked', true);
                        document.getElementById("txtbuachinh" + arr_ID[i]).value = "Bé ăn hết bữa chính. ";
                    }
                    $('input[name="buaphu' + arr_ID[i] + '"][value="' + _buaphu + '"]').attr('checked', true);
                }
            }
        }
    </script>
    <link rel="stylesheet" href="../../../web_VietNhatKids_css/SoLienLacDienTu/base.css" />
    <link href="../../../admin_css/css_index/Loading.css" rel="stylesheet" />
    <style>
        .dateCreate span {
            font-size: 20px;
            margin-right: 40px;
        }

        .table-bordered {
            border: none;
        }

            .table-bordered th, .table-bordered td {
                text-align: center;
            }

        .btnCalender {
            padding: 12px;
            color: #fff !important;
        }

        .table_baogiang th, .table_baogiang td {
            text-align: center;
            border: 1px solid #2d3846;
        }

        .table tr.tbheader {
            background: #a3a7a199;
        }

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
            font-size: 20px;
            padding: 10px 10px;
            color: white;
        }
    </style>
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
    <script>
        function DisplayLoadingIcon() {
            $("#img-loading-icon").show();
        }
    </script>
    <div class="loading" id="img-loading-icon" style="display: none">
        <div class="loading">Loading&#8230;</div>
    </div>
    <div class="main-omt">
        <div class="omt-header">
            <i class="fa fa-list-alt omt__icon" aria-hidden="true"></i>
            <h4 class="header-title">Nhận xét bé ăn hôm nay&nbsp; (<%=DateTime.Now.ToShortDateString() %>)</h4>
        </div>
        <div class="mt-2" id="div_Notification" runat="server">
            <h3 style="color: red; text-align: center">Giáo viên vui lòng vào điểm danh học sinh trước khi nhận xét!</h3>
        </div>
        <div class="card card-block" id="div_KetQua" runat="server">
            <div class="" style="margin: 20px 0; display: flex; justify-content: space-between;">
                <div class="dateCreate" style="display: flex; align-items: center">
                    <asp:Label ID="lblDateCreate" runat="server"></asp:Label>
                    <div style="display: flex;">
                        <h5 style="margin-bottom: 0">Lớp:
                            <asp:Label ID="rpSetLop" runat="server"></asp:Label>
                        </h5>
                    </div>
                </div>
                <div>
                    <a href="#" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLong">File hướng dẫn</a>
                    <a href="/admin-home" class="btn btn-primary">Quay lại</a>
                </div>
            </div>
            <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <embed src="../../../file_huongdan/nhan_xet_bua_an.pdf" width="1030" height="650" type="application/pdf" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table border="1" cellspacing="0" cellpadding="5" class="table table-bordered table_baogiang">
                    <tr class="tbheader">
                        <th>STT</th>
                        <th>Danh sách học sinh</th>
                        <th>Nhận xét bé ăn hôm nay</th>
                        <th>Ghi chú</th>
                    </tr>
                    <asp:Repeater ID="rpDanhSachHocSinh" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th>
                                    <%=STT++%>
                                </th>
                                <th>
                                    <%#Eval("hocsinh_name")%>
                                </th>
                                <td>
                                    <div style="display: flex; justify-content: space-around">
                                        <label class="mr-2">
                                            <input type="radio" id="ck01<%#Eval("hstl_id")%>" name="buachinh<%#Eval("hstl_id")%>" onclick="myBuaChinh(this.value, <%#Eval("hstl_id")%>)" value="Bé ăn hết bữa chính. " />
                                            Ăn hết bữa chính
                                        </label>
                                        <label>
                                            <input type="radio" id="ck02<%#Eval("hstl_id")%>" name="buachinh<%#Eval("hstl_id")%>" onclick="myBuaChinh(this.value, <%#Eval("hstl_id")%>)" value="Bé ăn còn lại bữa chính. " />
                                            Còn lại bữa chính
                                        </label>
                                    </div>
                                    <input type="text" class="form-control" id="txtbuachinh<%#Eval("hstl_id")%>" style="display: none" value="<%#Eval("nhanxet").ToString().Split('-')[0]%>" />

                                    <div style="display: flex; justify-content: space-around">
                                        <label class="mr-2">
                                            <input type="radio" id="ck03<%#Eval("hstl_id")%>" name="buaphu<%#Eval("hstl_id")%>" onclick="myBuaPhu(this.value, <%#Eval("hstl_id")%>)" value="Bé ăn hết bữa phụ. " />
                                            Ăn hết bữa phụ 
                                        </label>
                                        <label>
                                            <input type="radio" id="ck04<%#Eval("hstl_id")%>" name="buaphu<%#Eval("hstl_id")%>" onclick="myBuaPhu(this.value, <%#Eval("hstl_id")%>)" value="Bé ăn còn lại bữa phụ. " />
                                            Còn lại bữa phụ 
                                        </label>
                                    </div>
                                    <input type="text" class="form-control" id="txtbuaphu<%#Eval("hstl_id")%>" style="display: none" value="<%#Eval("nhanxet").ToString().Split('-')[1]%>" />
                                </td>
                                <td>
                                    <input type="text" class="form-control" id="txtghichu<%#Eval("hstl_id")%>" placeholder="Ghi chú bữa ăn..." value="<%#Eval("ghichu")%>" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <div>
                    <a class="btn btn-primary text-white" id="btnLuuTong" style="<%=mystyle %>" onclick="DisplayLoadingIcon();myContentTong()">Lưu</a>
                    <div style="display: none">
                        <input type="text" id="txtDanhSachHocSinhID" runat="server" />
                        <input type="text" id="txtHocSinhDau" runat="server" />
                        <input type="text" id="txtHocSinhCuoi" runat="server" />
                        <input type="text" id="txtContentTong" runat="server" />
                        <input type="text" id="txtGhiChuTong" runat="server" />
                    </div>
                    <a href="#" id="btnHoanThanh" runat="server" onserverclick="btnLuuTong_ServerClick"></a>
                </div>
            </div>
        </div>
        <script>
            function myContentTong() {
                //debugger;
                let sodau = document.getElementById("<%=txtHocSinhDau.ClientID%>").value;
                let socuoi = document.getElementById("<%=txtHocSinhCuoi.ClientID%>").value;
                let str_danhsachID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value;
                let ds_hocsinh = str_danhsachID.split(';');
                var content = [];
                var ghichu = [];
                for (let i = 0; i < ds_hocsinh.length; i++) {
                    var buachinh = (document.getElementById("txtbuachinh" + ds_hocsinh[i]).value);
                    var buaphu = (document.getElementById("txtbuaphu" + ds_hocsinh[i]).value);
                    var _ghichu = (document.getElementById("txtghichu" + ds_hocsinh[i]).value);
                    var _content = buachinh + "-" + buaphu;
                    content.push(_content);
                    ghichu.push(_ghichu);
                }
                document.getElementById("<%=txtContentTong.ClientID%>").value = content.join(";");
                document.getElementById("<%=txtGhiChuTong.ClientID%>").value = ghichu.join(";");
                document.getElementById("<%=btnHoanThanh.ClientID%>").click();
            }
        </script>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


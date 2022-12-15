<%@ Page Title="" Language="C#" MasterPageFile="~/Admin_MasterPage.master" AutoEventWireup="true" CodeFile="module_NhanXetSucKhoeHangNgay.aspx.cs" Inherits="admin_page_module_function_module_VietNhatKids_module_NhanXetSucKhoeHangNgay" %>

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
        function myTamTrang(value, id) {
            document.getElementById("txttamtrang" + id).value = value;
        }
        function myNguTrua(value, id) {
            document.getElementById("txtngutrua" + id).value = value;
        }
        function myNhietDo(value, id) {
            document.getElementById("txtnhietdo" + id).value = value;
        }
        function myDaiTien(value, id) {
            document.getElementById("txtdaitien" + id).value = value;
        }
        function setChecked() {
            var arr_ID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value.split(';');
            if (arr_ID != "") {
                for (var i = 0; i < arr_ID.length; i++) {
                    var _tamtrang = document.getElementById("txttamtrang" + arr_ID[i]).value;
                    var _ngutrua = document.getElementById("txtngutrua" + arr_ID[i]).value;
                    var _nhietdo = document.getElementById("txtnhietdo" + arr_ID[i]).value;
                    var _daitien = document.getElementById("txtdaitien" + arr_ID[i]).value;
                    if (_tamtrang != "") {
                        $('input[name="tamtrang' + arr_ID[i] + '"][value="' + _tamtrang + '"]').attr('checked', true);
                    }
                    else {
                        $('input[name="tamtrang' + arr_ID[i] + '"][value="Tâm trạng của bé bình thường."]').attr('checked', true);
                        document.getElementById("txttamtrang" + arr_ID[i]).value = "Tâm trạng của bé bình thường.";
                    }
                    if (_ngutrua != "") {
                        $('input[name="ngutrua' + arr_ID[i] + '"][value="' + _ngutrua + '"]').attr('checked', true);
                    }
                    else {
                        $('input[name="ngutrua' + arr_ID[i] + '"][value="Bé ngủ trưa tốt."]').attr('checked', true);
                        document.getElementById("txtngutrua" + arr_ID[i]).value = "Bé ngủ trưa tốt.";
                    }
                    if (_nhietdo != "") {
                        $('input[name="nhietdo' + arr_ID[i] + '"][value="' + _nhietdo + '"]').attr('checked', true);
                    }
                    else {
                        $('input[name="nhietdo' + arr_ID[i] + '"][value="Nhiệt độ bé bình thường."]').attr('checked', true);
                        document.getElementById("txtnhietdo" + arr_ID[i]).value = "Nhiệt độ bé bình thường.";
                    }
                    if (_daitien != "") {
                        $('input[name="daitien' + arr_ID[i] + '"][value="' + _daitien + '"]').attr('checked', true);
                    }
                    else {
                        $('input[name="daitien' + arr_ID[i] + '"][value="Bé không đi đại tiện."]').attr('checked', true);
                        document.getElementById("txtdaitien" + arr_ID[i]).value = "Bé không đi đại tiện.";
                    }
                }
            }
        }
        <%--function setForm() {
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
        }--%>
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
            <h4 class="header-title">Nhận xét sức khỏe trong ngày&nbsp; (<%=DateTime.Now.ToShortDateString() %>)</h4>
        </div>
        <div class="mt-2" id="div_Notification" runat="server">
            <h3 style="color: red; text-align: center">Giáo viên vui lòng vào điểm danh học sinh trước khi nhận xét!</h3>
        </div>
        <div class="card card-block" id="div_KetQua" runat="server">
            <div class="" style="margin: 20px 0; display: flex; justify-content: space-between">
                <div class="dateCreate" style="display: flex; align-items: center">
                    <asp:Label ID="lblDateCreate" runat="server"> </asp:Label>
                    <div style="display: flex;"> 
                        <h5 style="margin-right: 12px;">Lớp:</h5>
                        <h5 style="margin-bottom: 0">
                            <asp:Label ID="rpSetLop" runat="server">
                            </asp:Label>
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
                            <embed src="../../../file_huongdan/nhan_xet_suc_khoe_trong_ngay.pdf" width="1030" height="650" type="application/pdf" />
                        </div>
                    </div>
                </div>
            </div>
            <div>
                <table border="1" cellspacing="0" cellpadding="5" class="table table-bordered table_baogiang">
                    <tr class="tbheader">
                        <th>STT</th>
                        <th>Danh sách học sinh</th>
                        <th>Nhận xét sức khỏe của bé hôm nay</th>
                        <th>Ghi chú</th>
                    </tr>
                    <asp:Repeater ID="rpDanhSachHocSinh" runat="server">
                        <ItemTemplate>
                            <tr>
                                <th>
                                    <%#Container.ItemIndex+1 %>
                                </th>
                                <th>
                                    <%#Eval("hocsinh_name")%>
                                </th>
                                <td>
                                    <table>
                                        <tr>
                                            <th>Tâm trạng</th>
                                            <th>
                                                <div style="display: flex; justify-content: space-around">
                                                    <label class="mr-2">
                                                        Tốt
                                                        <br />
                                                        <input type="radio" id="ck01<%#Eval("hstl_id")%>" name="tamtrang<%#Eval("hstl_id")%>" onclick="myTamTrang(this.value, <%#Eval("hstl_id")%>)" value="Tâm trạng của bé tốt." />
                                                    </label>
                                                    <label class="mr-2">
                                                        Bình thường
                                                        <br />
                                                        <input type="radio" id="ck02<%#Eval("hstl_id")%>" name="tamtrang<%#Eval("hstl_id")%>" onclick="myTamTrang(this.value, <%#Eval("hstl_id")%>)" value="Tâm trạng của bé bình thường." />
                                                    </label>
                                                    <label>
                                                        Xấu
                                                        <br />
                                                        <input type="radio" id="ck03<%#Eval("hstl_id")%>" name="tamtrang<%#Eval("hstl_id")%>" onclick="myTamTrang(this.value, <%#Eval("hstl_id")%>)" value="Tâm trạng của bé xấu." />
                                                    </label>
                                                </div>
                                                <input type="text" class="form-control" id="txttamtrang<%#Eval("hstl_id")%>" value="<%#Eval("tamtrang").ToString().Split('-')[0]%>" style="display: none" />
                                            </th>
                                            <th>Ngủ trưa</th>
                                            <th>
                                                <div style="display: flex; justify-content: space-around">
                                                    <label class="mr-2">
                                                        Tốt
                                                        <br />
                                                        <input type="radio" id="ck04<%#Eval("hstl_id")%>" name="ngutrua<%#Eval("hstl_id")%>" onclick="myNguTrua(this.value, <%#Eval("hstl_id")%>)" value="Bé ngủ trưa tốt." />
                                                    </label>
                                                    <label>
                                                        Không tốt
                                                        <br />
                                                        <input type="radio" id="ck05<%#Eval("hstl_id")%>" name="ngutrua<%#Eval("hstl_id")%>" onclick="myNguTrua(this.value, <%#Eval("hstl_id")%>)" value="Bé ngủ trưa không tốt." />
                                                    </label>
                                                </div>
                                                <input type="text" class="form-control" id="txtngutrua<%#Eval("hstl_id")%>" value="<%#Eval("tamtrang").ToString().Split('-')[1]%>" style="display: none" />
                                            </th>
                                        </tr>
                                        <tr>
                                            <th>Nhiệt độ</th>
                                            <th>
                                                <div style="display: flex; justify-content: space-around">
                                                    <label class="mr-2">
                                                        Bình thường
                                                        <br />
                                                        <input type="radio" id="ck06<%#Eval("hstl_id")%>" name="nhietdo<%#Eval("hstl_id")%>" onclick="myNhietDo(this.value, <%#Eval("hstl_id")%>)" value="Nhiệt độ bé bình thường." />
                                                    </label>
                                                    <label>
                                                        Có sốt
                                                        <br />
                                                        <input type="radio" id="ck07<%#Eval("hstl_id")%>" name="nhietdo<%#Eval("hstl_id")%>" onclick="myNhietDo(this.value, <%#Eval("hstl_id")%>)" value="Bé có sốt." />

                                                    </label>
                                                </div>

                                                <input type="text" class="form-control" id="txtnhietdo<%#Eval("hstl_id")%>" value="<%#Eval("tamtrang").ToString().Split('-')[2]%>" style="display: none" />
                                            </th>
                                            <th>Đại tiện</th>
                                            <th>
                                                <div style="display: flex; justify-content: space-around">
                                                    <label class="mr-2">
                                                        Có
                                                        <br />
                                                        <input type="radio" id="ck08<%#Eval("hstl_id")%>" name="daitien<%#Eval("hstl_id")%>" onclick="myDaiTien(this.value, <%#Eval("hstl_id")%>)" value="Bé có đi đại tiện." />

                                                    </label>
                                                    <label>
                                                        Không
                                                        <br />
                                                        <input type="radio" id="ck09<%#Eval("hstl_id")%>" name="daitien<%#Eval("hstl_id")%>" onclick="myDaiTien(this.value, <%#Eval("hstl_id")%>)" value="Bé không đi đại tiện." />
                                                    </label>
                                                </div>
                                                <input type="text" class="form-control" id="txtdaitien<%#Eval("hstl_id")%>" value="<%#Eval("tamtrang").ToString().Split('-')[3]%>" style="display: none" />
                                            </th>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <input type="text" class="form-control" id="txtghichu<%#Eval("hstl_id")%>" placeholder="Ghi chú sức khỏe..." value="<%#Eval("ghichu")%>" />
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
    </div>

    <script>
        function myContentTong() {
            //debugger;
           <%-- let sodau = document.getElementById("<%=txtHocSinhDau.ClientID%>").value;
            let socuoi = document.getElementById("<%=txtHocSinhCuoi.ClientID%>").value;--%>
            let str_danhsachID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value;
            let ds_hocsinh = str_danhsachID.split(';');
            var content = [];
            var ghichu = [];
            for (let i = 0; i < ds_hocsinh.length; i++) {
                var tamtrang = (document.getElementById("txttamtrang" + ds_hocsinh[i]).value);
                var ngutrua = (document.getElementById("txtngutrua" + ds_hocsinh[i]).value);
                var nhietdo = (document.getElementById("txtnhietdo" + ds_hocsinh[i]).value);
                var daitien = (document.getElementById("txtdaitien" + ds_hocsinh[i]).value);
                var _ghichu = (document.getElementById("txtghichu" + ds_hocsinh[i]).value);
                //if (content == '')
                var _content = tamtrang + "-" + ngutrua + "-" + nhietdo + "-" + daitien;
                //else
                content.push(_content);
                //if (ghichu == '')
                //    ghichu = _ghichu;
                //else
                ghichu.push(_ghichu);
            }
            //console.log(content, ghichu)
            document.getElementById("<%=txtContentTong.ClientID%>").value = content.join(";");
            document.getElementById("<%=txtGhiChuTong.ClientID%>").value = ghichu.join(";");
            console.log(ghichu, content);
            document.getElementById("<%=btnHoanThanh.ClientID%>").click();
        }
       <%-- window.onload = function () {
            let str_danhsachID = document.getElementById("<%=txtDanhSachHocSinhID.ClientID%>").value.split(';');
            for (var i = 0; i < str_danhsachID.length; i++) {
                $("#ck01" + str_danhsachID[i]).prop('checked', true);
                document.getElementById("txt" + str_danhsachID[i]).value = "Bé ăn hết bữa chính. ";
            }
        };--%>
    </script>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="hibodybottom" runat="Server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="hifooter" runat="Server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="hifootersite" runat="Server">
</asp:Content>


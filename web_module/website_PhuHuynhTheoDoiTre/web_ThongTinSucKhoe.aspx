<%@ Page Title="" Language="C#" MasterPageFile="~/Website_MasterPage.master" AutoEventWireup="true" CodeFile="web_ThongTinSucKhoe.aspx.cs" Inherits="web_ThongTinSucKhoe" %>

<%@ Register Src="~/web_usercontrol/Web_ThongTinCaNhan.ascx" TagPrefix="uc1" TagName="Web_ThongTinCaNhan" %>
<%@ Register Src="~/web_usercontrol/Web_ThanhChucnang.ascx" TagPrefix="uc1" TagName="Web_ThanhChucnang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.js"></script>
    <style>
        * {
            margin: 0;
            padding: 0;
        }

        body {
            background-color: #e7e7e8;
        }

        .container_left {
            padding: 0 1%;
            border-radius: 10px;
            display: flex;
            margin: 1% 0;
            flex-direction: column;
            flex-wrap: nowrap;
            justify-content: space-around;
            text-align: center;
        }

        .container_left_top {
            background-color: #ffffff;
            flex-direction: column;
            flex-wrap: nowrap;
            align-items: center;
            color: #B51A1A;
            font-weight: bold;
        }

        .container_right {
            background-color: #ffffff;
            border-radius: 10px;
            padding: 1%;
            overflow: auto;
            margin-left: 0;
            height: 31.75rem;
            box-shadow: 2px 3px 8px 5px #80808029;
            margin: 1% 0;
            overflow-x: hidden;
            overflow-y: auto;
        }

        .table {
            width: 100%;
            max-width: 100%;
            background-color: transparent;
            text-align: center;
            height: 50%;
        }

        .h4, h4 {
            font-size: 18px;
            text-align: center;
        }

        select {
            background-color: #ffffff;
            border: none;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
        }

        thead {
            background-color: #f7e8e3;
            border: 2px solid #f1ae98;
        }

        tr {
            border-bottom: 1.5px solid #f1ae98;
        }

        .row {
            margin: 0;
            padding: 0 !important;
        }
        /*.row {
            padding: 0 !important;*/
        /*height: 600px;*/
        /*margin-right: -87px;
        }*/

        .block-bieudo {
            background-color: #ffffff;
            width: 100%;
            border-radius: 10px;
            padding: 1%;
            display: flex;
            flex-direction: column;
            justify-content: space-around;
            height: 31.75rem;
            box-shadow: 2px 3px 8px 5px #80808029;
        }

        .table td, .table th {
            padding: 0.5rem;
        }

        .table thead th {
            background: #a10101;
            font-weight: 500;
            color: white;
            padding: 5px;
            border: 1px solid white;
        }
        
            
       
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container-fluid row">
        <div class="col-xl-3 col-md-12 float-left">
            <uc1:Web_ThongTinCaNhan runat="server" ID="Web_ThongTinCaNhan" />
        </div>
        <%-- <div class="col-xl-9 col-md-12 float-right" style="padding: 0">--%>
        <div class="col-xl-9 col-md-12">
            <div class="col-xl-12 col-md-12 userrp" style="padding: 0">
                <uc1:Web_ThanhChucnang runat="server" ID="Web_ThanhChucnang" />
            </div>
            <div class="col-12 row" style="padding: 0; margin: 0">
                <div class="container_left col-4" style="padding-left: 0">
                    <div class="block-bieudo">
                        <div class="container_left_top">
                            <div>
                                <h4 style="color: #940808; font-weight: bold;">BIỂU ĐỒ CHIỀU CAO</h4>
                            </div>
                            <canvas id="myChart" style="width: 100%; max-width: 400px"></canvas>
                        </div>
                        <div class="container_left_top">
                            <div>
                                <h4 style="color: #940808; font-weight: bold;">BIỂU ĐỒ CÂN NĂNG</h4>
                            </div>
                            <canvas id="myChart1" style="width: 100%; max-width: 400px"></canvas>
                        </div>
                    </div>

                </div>
                <div class="container_right col-8">
                    <div>
                        <h4 style="font-size: 20px; font-weight: bold; color: #1f58c1; text-transform: uppercase; /* color: aqua; */">Theo dõi sức khỏe năm
                            <asp:Label runat="server" ID="lblNam"> </asp:Label></h4>
                    </div>
                    <div>
                        <div>
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">STT</th>
                                        <th scope="col">Tháng</th>
                                        <th scope="col">Chiều cao(cm)</th>
                                        <th scope="col">Cân nặng(kg)</th>
                                        <th scope="col">Ghi chú</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rpSucKhoe" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td scope="row"><%= STT++ %></td>
                                                <td><%#Eval("thang_name") %></td>
                                                <td><%#Eval("suckhoe_chieucao") %></td>
                                                <td><%#Eval("suckhoe_cannang") %></td>
                                                <td><%#Eval("suckhoe_ghichu") %></td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: none">
            <input id="txtThang" runat="server" />
            <input id="txtCanNang" runat="server" />
            <input id="txtChieuCao" runat="server" />
        </div>
    </div>
    <%-- </div>--%>
    <script>
        var arr_thang = document.getElementById("<%=txtThang.ClientID %>").value.split(",");

        var arr_NameMonth = [];
        for (var i = 0; i < arr_thang.length; i++) {
            arr_NameMonth[i] = arr_thang[i].replace(/[^0-9]/g, '');
        }
        console.log(arr_NameMonth);
        var arr_CanNang = document.getElementById("<%=txtCanNang.ClientID %>").value.split(",");
        console.log(arr_CanNang);
        var arr_ChieuCao = document.getElementById("<%=txtChieuCao.ClientID %>").value.split(",");
        console.log(arr_ChieuCao);


        new Chart("myChart", {
            type: "line",
            data: {
                labels: arr_NameMonth,
                datasets: [{
                    fill: false,
                    lineTension: 0,
                    backgroundColor: "rgba(0,0,255,1.0)",
                    borderColor: "rgba(0,0,255,0.1)",
                    data: arr_ChieuCao
                }]
            },
            options: {
                legend: { display: false },
                //scales: {
                //    yAxes: [{ ticks: { min: 1, max: 16 } }],
                //}
            }
        });

        new Chart("myChart1", {
            type: "line",
            data: {
                labels: arr_NameMonth,
                datasets: [{
                    fill: false,
                    lineTension: 0,
                    backgroundColor: "rgba(0,0,255,1.0)",
                    borderColor: "rgba(0,0,255,0.1)",
                    data: arr_CanNang
                }]
            },
            options: {
                legend: { display: false },

            }
        });

    </script>
</asp:Content>


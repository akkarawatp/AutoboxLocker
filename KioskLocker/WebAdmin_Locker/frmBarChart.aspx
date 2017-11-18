<%@ Page Language="VB" AutoEventWireup="false" CodeFile="frmBarChart.aspx.vb" Inherits="frmBarChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

        <asp:Chart ID="BarChart" runat="server" Width="1000px">
            <Titles>
                <asp:Title Text="Frequency Service Time in This Month"></asp:Title>
            </Titles>
           <%-- <Series>
                <asp:Series Name="DEPOSIT"  ChartArea="MainChartArea"  BorderWidth="5" IsValueShownAsLabel="True" LabelFormat="F2"></asp:Series>
                <asp:Series Name="COLLECT"  ChartArea="MainChartArea"  BorderWidth="5" IsValueShownAsLabel="True" LabelFormat="F2"></asp:Series>
            </Series>--%>
            <Legends>
                <asp:Legend Alignment="Center" Docking="bottom" Name="Legend1">
                </asp:Legend>
            </Legends>
            <ChartAreas>
                <asp:ChartArea Name="MainChartArea" AlignmentOrientation="Horizontal"></asp:ChartArea>
            </ChartAreas>
        </asp:Chart>


    </div>

       
    </form>
</body>
</html>

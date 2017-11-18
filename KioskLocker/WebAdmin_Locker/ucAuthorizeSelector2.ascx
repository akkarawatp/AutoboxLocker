<%@ Control Language="vb" AutoEventWireup="false" CodeFile="ucAuthorizeSelector2.ascx.vb" Inherits="ucAuthorizeSelector2" %>
<div class="btn-group btn-group-justified">
    <asp:LinkButton id="aRoleNA" runat="server" CssClass="btn btn-default" role="0"><i class="climacon moon new"></i> N/A</asp:LinkButton>    
    <asp:LinkButton id="aRoleView" runat="server" CssClass="btn btn-default" role="1"><i class="climacon moon new"></i> View</asp:LinkButton>        
</div>
<asp:CheckBox ID="chkVisible" runat="server" Style="display:none;" Checked="true" />
<asp:CheckBox ID="chkEnable" runat="server" Style="display:none;" Checked="true" />
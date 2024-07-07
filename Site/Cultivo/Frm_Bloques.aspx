<%@ Page Title="" Language="C#" MasterPageFile="~/SGF_Site.Master" AutoEventWireup="true" CodeBehind="Frm_Bloques.aspx.cs" Inherits="SGF.Site.Cultivo.Frm_Bloques" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .cuadro {
            border: 1px solid #ccc;
            padding: 2px;
            margin: 1px;
            border-color: YellowGreen;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hdn_CultivoArea" runat="server" />
    <asp:HiddenField ID="hdn_CultivoBloque" runat="server" />
    <asp:HiddenField ID="hdn_CultivoLado" runat="server" />
    <asp:HiddenField ID="hdn_CultivoNave" runat="server" />
    <asp:HiddenField ID="hdn_CultivoCama" runat="server" />
    <asp:HiddenField ID="hdn_CultivoCuadro" runat="server" />
    <asp:HiddenField ID="hdn_CampoCultivoID" runat="server" />
    <asp:HiddenField ID="hdn_VariedadID" runat="server" />
    <%-- <telerik:RadWindowManager ID="wnd_manager" runat="server" ShowContentDuringLoad="false"
        VisibleStatusbar="false" ReloadOnShow="true" EnableShadow="true">
        <Windows>
            <telerik:RadWindow ID="wnd_Persona" runat="server" Width="650" Height="500" NavigateUrl="~/Frm_BuscarProveedor.aspx" Modal="true"
                OnClientClose="OnClientClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>--%>

    <table width="100%">
        <tr>
            <td align="center">
                <asp:Label runat="server" ID="lbl_Titulo" Text="MAPA DE CULTIVO" Font-Size="Large" Font-Bold="true"></asp:Label>
            </td>
        </tr>
    </table>


    <table>
        <tr>
            <td>Número de Áreas:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroAreas" runat="server" MinValue="0" Value="0" Width="50px">
                    <NumberFormat DecimalDigits="0" />
                </telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextAreas" runat="server" Text="Cantidad Máxima de Áreas para seleccionar:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextAreasValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>Número de Bloques por Área:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroBloques" runat="server" Value="0" NumberFormat-DecimalDigits="0" MinValue="0" Width="50px"></telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextBloques" runat="server" Text="Cantidad Máxima de Bloques por Área:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextBloquesValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>Número de Lados por Bloque:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroLados" runat="server" Value="0" NumberFormat-DecimalDigits="0" ShowSpinButtons="false" MinValue="0" Width="50px"></telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextLados" runat="server" Text="Cantidad Máxima de Lados por Bloque:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextLadosValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>Número de Naves por Lado:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroNaves" runat="server" Value="0" NumberFormat-DecimalDigits="0" ShowSpinButtons="false" MinValue="0" Width="50px"></telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextNaves" runat="server" Text="Cantidad Máxima de Naves por Lado:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextNavesValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>Número de Camas por Lado:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroCamas" runat="server" Value="0" NumberFormat-DecimalDigits="0" ShowSpinButtons="false" MinValue="0" Width="50px"></telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextCamas" runat="server" Text="Cantidad Máxima de Camas por Naves:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextCamasValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>Número de Cuadros por Cama:</td>
            <td>
                <telerik:RadNumericTextBox ID="txt_NroCuadros" runat="server" Value="0" NumberFormat-DecimalDigits="0" ShowSpinButtons="false" MinValue="0" Width="50px"></telerik:RadNumericTextBox>
            </td>
            <td>
                <telerik:RadLabel ID="lbl_TextCuadros" runat="server" Text="Cantidad Máxima de Cuadros por Cama:"></telerik:RadLabel>
                <telerik:RadLabel ID="lbl_TextCuadrosValor" runat="server" Text=""></telerik:RadLabel>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadButton ID="btn_GenerarCampo" runat="server" Text="Generar Mapa de Cultivo" Height="40px" Visible="true" OnClick="btn_GenerarCampo_Click">
                    <Icon PrimaryIconUrl="~/Images/Cotizar.png" PrimaryIconTop="4px" PrimaryIconLeft="5px" PrimaryIconHeight="50px" PrimaryIconWidth="40px" />
                </telerik:RadButton>
            </td>
            <td></td>
            <td></td>
        </tr>
    </table>

    <table>
        <tr>
            <td>
                <asp:DataList ID="dlArea" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" BorderStyle="Double" Visible="false">
                    <ItemTemplate>
                        <div class="area">
                            <h1>Área: <%# Eval("Nombre") %></h1>
                            <asp:DataList ID="dlBloques" runat="server" RepeatColumns="2" DataSource='<%# Eval("Bloques") %>' RepeatDirection="Horizontal" BorderStyle="Solid">
                                <ItemTemplate>
                                    <div class="bloque">
                                        <h2>Bloque: <%# Eval("Nombre") %></h2>

                                        <asp:DataList ID="dlEstanterias" runat="server" RepeatColumns="2" DataSource='<%# Eval("Estanterias") %>' RepeatDirection="Horizontal" BorderStyle="Ridge">
                                            <ItemTemplate>
                                                <div class="estanteria">
                                                    <h3>Estantería: <%# Eval("Nombre") %></h3>

                                                    <asp:DataList ID="dlSecciones" runat="server" RepeatColumns="2" DataSource='<%# Eval("Secciones") %>' RepeatDirection="Horizontal" BorderStyle="Dashed">
                                                        <ItemTemplate>
                                                            <div class="seccion">
                                                                <h4>Sección: <%# Eval("Nombre") %></h4>
                                                                Descripción: <%# Eval("Descripcion") %>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </div>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <hr />
                                    <hr />
                                </SeparatorTemplate>
                            </asp:DataList>
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                        <hr />
                    </SeparatorTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>

    <table>
        <tr>
            <td>
                <asp:DataList ID="dlAreas" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" BorderStyle="Double" Style="text-align: center">
                    <ItemTemplate>
                        <div class="area">
                            <%--                            <h1>Área: <%# Eval("Nombre") %></h1>--%>
                            <telerik:RadButton ID="btn_Area" runat="server" RenderMode="Lightweight" Text='<%# Eval("Nombre") %>' Width="97%" Height="30px" Font-Bold="true" Font-Size="X-Large"></telerik:RadButton>
                            <asp:DataList ID="dlBloques" runat="server" RepeatColumns="2" DataSource='<%# Eval("SGF_CultivoBloque") %>' RepeatDirection="Horizontal" BorderStyle="Solid">
                                <ItemTemplate>
                                    <div class="bloque">
                                        <%--                                        <h2>Bloque: <%# Eval("Nombre") %></h2>--%>
                                        <telerik:RadButton ID="btn_Bloque" runat="server" RenderMode="Lightweight" Text='<%# Eval("Nombre") %>' Width="96%" Height="28px" Font-Bold="true" Font-Size="Large"></telerik:RadButton>
                                        <asp:DataList ID="dlLados" runat="server" RepeatColumns="2" DataSource='<%# Eval("SGF_CultivoLado") %>' RepeatDirection="Horizontal" BorderStyle="Groove" BorderColor="#ff6600">
                                            <ItemTemplate>
                                                <div class="lado">
                                                    <%--                                                    <h3>Lado: <%# Eval("Nombre") %></h3>--%>
                                                    <telerik:RadButton ID="btn_Lado" runat="server" RenderMode="Lightweight" Text='<%# Eval("Nombre") %>' Width="93%" BorderStyle="None" Height="25px" Font-Bold="true" Font-Size="Medium"></telerik:RadButton>
                                                    <asp:DataList ID="dlNaves" runat="server" DataSource='<%# Eval("SGF_CultivoNave") %>' RepeatDirection="Vertical" BorderStyle="Solid" BorderColor="#006600">
                                                        <ItemTemplate>
                                                            <div class="nave">
                                                                <%--                                                                <h3>Nave: <%# Eval("Nombre") %></h3>--%>
                                                                <telerik:RadButton ID="btn_Nave" runat="server" RenderMode="Lightweight" Text='<%# Eval("Nombre") %>' Width="93%" BorderStyle="None" Height="25px" Font-Bold="true" Font-Size="Larger"></telerik:RadButton>
                                                                <asp:DataList ID="dlCamas" runat="server" DataSource='<%# Eval("SGF_CultivoCama") %>' RepeatDirection="Vertical" BorderStyle="Groove" BorderColor="Blue" Style="text-align: left">
                                                                    <ItemTemplate>
                                                                        <div class="cama">
                                                                            <%--                                                                            <h3>Cama: <%# Eval("Nombre") %></h3>--%>
                                                                            <telerik:RadButton ID="btn_Cama" runat="server" RenderMode="Lightweight" Text='<%# Eval("Nombre") %>' Width="93%" BorderStyle="None" Height="25px" Font-Bold="true" Font-Size="Small" Style="text-align: left"></telerik:RadButton>
                                                                            <asp:DataList ID="dlCuadros" runat="server" RepeatColumns="4" DataSource='<%# Eval("SGF_CultivoCuadro") %>' RepeatDirection="Horizontal" BorderStyle="Solid" BorderColor="Cyan">
                                                                                <ItemTemplate>
                                                                                    <div class="cuadro">
                                                                                        <telerik:RadButton ID="btn_Cuadro" runat="server" Text='<%# Eval("Nombre") %>' ButtonType="StandardButton" Width="60px" Font-Italic="true" Height="20px"></telerik:RadButton>
                                                                                    </div>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:DataList>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                                <hr />                                               
                                                <hr />                                               
                                                <hr />                                               
                                            </SeparatorTemplate>
                                        </asp:DataList>
                                    </div>
                                </ItemTemplate>
                                <SeparatorTemplate>
                                    <hr />
                                </SeparatorTemplate>
                            </asp:DataList>
                        </div>
                    </ItemTemplate>
                    <SeparatorTemplate>
                        <hr />
                    </SeparatorTemplate>
                </asp:DataList>
            </td>
        </tr>
    </table>
</asp:Content>

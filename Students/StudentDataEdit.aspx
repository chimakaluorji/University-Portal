<%@ Page Title="" Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentDataEdit.aspx.vb" Inherits="Students_StudentDataEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Student Edit Data</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="index.html">Home</a>
                </li>
                <li class="active">
                    <strong>Student Data</strong>
                </li>
            </ol>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="wrapper wrapper-content animated fadeInRight">
        <div class="row">
            <div class="col-lg-12">
                <div class="ibox float-e-margins">
                    <div class="ibox-title">
                        <h5>Basic Wizzard</h5>
                        <div class="ibox-tools">
                            <a class="collapse-link">
                                <i class="fa fa-chevron-up"></i>
                            </a>
                            <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                                <i class="fa fa-wrench"></i>
                            </a>
                            <ul class="dropdown-menu dropdown-user">
                                <li><a href="#">Config option 1</a>
                                </li>
                                <li><a href="#">Config option 2</a>
                                </li>
                            </ul>
                            <a class="close-link">
                                <i class="fa fa-times"></i>
                            </a>
                        </div>
                    </div>
                    <div class="ibox-content">
                        <div id="wizard">
                            <h1>Bio Data</h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Registration No: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtPIN" runat="server" CssClass="form-control" placeholder="Reg No" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Surname: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="TxtSurname" runat="server" CssClass="form-control" placeholder="Surname" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Firstname: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="TxtFirstname" runat="server" CssClass="form-control" placeholder="Firstname" required data-title="Please enter your name"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Midle Name: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="TxtmidleName" runat="server" CssClass="form-control" placeholder="Middle Name" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Mothers Maiden Name: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="txtMotherMaidenName" runat="server" CssClass="form-control" placeholder="Mothers Maiden Name" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                     <div class="form-group" id="data_1">
                                        <label class="col-lg-2 control-label">Date of Birth: </label>
                                        <div class="input-group date">
                                            <span class="input-group-addon"><i class="fa fa-calendar"></i></span><input type="text" class="form-control" value="03/04/2014">
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Firstname: </label>
                                        <div class="col-lg-10">
                                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Firstname" required=""></asp:TextBox>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">Sex: </label>
                                        <div class="col-lg-10">
                                            <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" Width="100px">
                                                  <asp:ListItem Selected="True">Male</asp:ListItem>
                                                  <asp:ListItem>Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                </div>
                            </div>

                            <h1>Nationality</h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                <div class="form-group">
                                        <div class="col-lg-10">
                                          <div class="sk-spinner sk-spinner-circle" id="spinner" style="display: none;">
                                                    <div class="sk-circle1 sk-circle"></div>
                                                    <div class="sk-circle2 sk-circle"></div>
                                                    <div class="sk-circle3 sk-circle"></div>
                                                    <div class="sk-circle4 sk-circle"></div>
                                                    <div class="sk-circle5 sk-circle"></div>
                                                    <div class="sk-circle6 sk-circle"></div>
                                                    <div class="sk-circle7 sk-circle"></div>
                                                    <div class="sk-circle8 sk-circle"></div>
                                                    <div class="sk-circle9 sk-circle"></div>
                                                    <div class="sk-circle10 sk-circle"></div>
                                                    <div class="sk-circle11 sk-circle"></div>
                                                    <div class="sk-circle12 sk-circle"></div>
                                                </div>
                                        </div>
                                    </div>
                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">State:</label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" DataSourceID="odsState"
                                                            DataTextField="StateName" DataValueField="StateID" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                                      <asp:ObjectDataSource ID="odsState" runat="server" EnableCaching="True"
                                                           SelectMethod="FindAllStates" TypeName="CountryStateLGADAL">
                                                      </asp:ObjectDataSource>
                                        </div>
                                    </div>

                                    <div>&nbsp;</div>
                                    <div class="form-group">
                                        <label class="col-lg-2 control-label">LGA: </label>
                                        <div class="col-lg-10">
                                             <asp:DropDownList ID="ddlLGA" runat="server" AppendDataBoundItems="True" CssClass="form-control">
                                                          <asp:ListItem Value="0">--Please Select--</asp:ListItem>
                                                      </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                               
                            <h1>Third Step</h1>
                            <div class="step-content">
                                <div class="text-center m-t-md">
                                    <h2>This is step 3</h2>
                                    <p>
                                        This is last content.
                                   
                                    </p>
                                </div>
                            </div>
                        </div>

                    </div>
                    
                </div>
            </div>
        </div>
    </div>


<%--New Implementation of jquery button submit--%>
<script type="text/javascript" src="js/jquery-1.8.2.js"></script>
<script type="text/javascript">

    $(function () {
        $(document).on("change", "[id*=ddlState]", function () {
            //alert($("[id*=ddlState]").find("option:selected").text());
            var StateID = $("[id*=ddlState]").find("option:selected").val()

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentDataEdit.aspx/GetLGA",
                data: "{'EStateID':'" + StateID + "'}",
                dataType: "json",
                success: function (data) {

                    var ddlLGA = $("[id*=ddlLGA]");
                    ddlLGA.empty().append('<option selected="selected" value="0">--Please select--</option>');
                    $.each(data.d, function () {
                        ddlLGA.append($("<option></option>").val(this['Value']).html(this['Text']));
                    });

                },
                beforeSend: function () {
                    // Code to display spinner
                    $('#spinner1').show();
                },
                complete: function () {
                    // Code to hide spinner.
                    $('#spinner1').hide();
                },
                error: function (result) {
                    alert('Error Occured.');
                }
            });

        });
});
</script>
</asp:Content>



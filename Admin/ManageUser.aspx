<%@ Page Language="VB" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="false" CodeFile="ManageUser.aspx.vb" Inherits="Admin_ManageUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  <link href="css/solidrock.css" rel="stylesheet" type="text/css" />
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">

    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">

    <link href="css/plugins/chosen/chosen.css" rel="stylesheet">

    <link href="css/plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet">

    <link href="css/plugins/cropper/cropper.min.css" rel="stylesheet">

    <link href="css/plugins/switchery/switchery.css" rel="stylesheet">

    <link href="css/plugins/jasny/jasny-bootstrap.min.css" rel="stylesheet">

    <link href="css/plugins/nouslider/jquery.nouislider.css" rel="stylesheet">

    <link href="css/plugins/datapicker/datepicker3.css" rel="stylesheet">

    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.css" rel="stylesheet">
    <link href="css/plugins/ionRangeSlider/ion.rangeSlider.skinFlat.css" rel="stylesheet">

    <link href="css/plugins/awesome-bootstrap-checkbox/awesome-bootstrap-checkbox.css" rel="stylesheet">

    <link href="css/plugins/clockpicker/clockpicker.css" rel="stylesheet">

    <link href="css/plugins/daterangepicker/daterangepicker-bs3.css" rel="stylesheet">

    <link href="css/plugins/select2/select2.min.css" rel="stylesheet">

    <link href="css/plugins/touchspin/jquery.bootstrap-touchspin.min.css" rel="stylesheet">


     <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="font-awesome/css/font-awesome.css" rel="stylesheet">
    <link href="css/plugins/iCheck/custom.css" rel="stylesheet">
   <link href="css/plugins/steps/jquery.steps.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">   

    <div class="row wrapper border-bottom white-bg page-heading">
        <div class="col-lg-10">
            <h2>Manage Users</h2>
            <ol class="breadcrumb">
                <li>
                    <a href="Default.aspx">Dashboard</a>
                </li>

                <li class="active">
                    <strong>Manage Users</strong>
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
                    <div class="wrapper wrapper-content animated fadeInRight">

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="ibox float-e-margins">
                                    <div class="ibox-title">
                                        <h5>Manage Users</h5>
                                        <br />
                                        <asp:Label ID="lblError" runat="server" Text="" Font-Size="15px" Font-Bold="true"></asp:Label>
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
                                        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#myModal2">
                                            Add Users
                                        </button>
                                        <div class="table-responsive">
                                            <table class="table table-striped table-bordered table-hover dataTables-example" id="editable1">
                                                <thead>
                                                    <tr>
                                                        <th>UserName</th>
                                                        <th>FirstName</th>
                                                        <th>Surname</th>
                                                        <th>Phone Number</th>
                                                        <th>Email Address</th>
                                                        <th>Edit or Delete</th>
                                                    </tr>
                                                </thead>
                                                <%
                                                    Dim SSDDal As LoginDAL = New LoginDAL
                                                    Dim RetDataSet As System.Data.DataSet = New System.Data.DataSet
                        
                                                    RetDataSet = SSDDal.FindAllUsers()
                                                %>
                                                <% For i = 0 To RetDataSet.Tables(0).Rows.Count - 1%>
                                                <tbody>
                                                    <tr class="gradeX">
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("UserName")%></td>
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("FirstName")%></td>
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("Surname")%></td>
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("Phone")%></td>
                                                        <td><%= RetDataSet.Tables(0).Rows(i).Item("Email")%></td>
                                                        <td><a href='#myModal' data-toggle="modal" data-target="#myModal3" id='<%= RetDataSet.Tables(0).Rows(i).Item("UserId")%>'><i class="fa fa-check text-navy"></i></a></td>

                                                    </tr>
                                                </tbody>
                                                <% Next%>

                                                <tfoot>
                                                    <tr>
                                                        <th>UserName</th>
                                                        <th>FirstName</th>
                                                        <th>Surname</th>
                                                        <th>Phone Number</th>
                                                        <th>Email Address</th>
                                                        <th>Edit or Delete</th>
                                                    </tr>
                                                </tfoot>
                                            </table>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <div class="modal inmodal" id="myModal2" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Add New User</h4>

                </div>


                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">

                            <div class="form-group">
                                <label class="col-lg-3 control-label">User Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">First Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Surname: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtSurname" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Password: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Confirm Password: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Phone Number: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Phone Number"></asp:TextBox>
                                </div>
                            </div>
                           
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Email Address: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Passport Photography: </label>
                                  <div class="col-lg-9">
                                     <div class="panel panel-success" menuitemname="Client Shortcuts">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title"><i class="fa fa-bookmark"></i>&nbsp;Image Capturing</h3>
                                                </div>
                                                <div>&nbsp;</div>
                                                <div style="padding: 0 10px 0 10px;">
                                                    <div class="fileinput fileinput-new" data-provides="fileinput">
                                                        <div class="fileinput-preview thumbnail" data-trigger="fileinput" style="width: 200px; height: 150px;"></div>
                                                        <div>
                                                            <span class="btn btn-success btn-file"><span class="fileinput-new">Select Passport Photography</span>
                                                                <span class="fileinput-exists">Change</span>
                                                                <asp:FileUpload ID="fileupload1" runat="server" required /></span>
                                                            <a href="#" class="btn btn-default fileinput-exists" data-dismiss="fileinput">Remove</a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                          </div>  
                               </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    
                          <div class="alert alert-success" id="success" style="display:none;">
                               The User was successfully Created. Manage Users will start afresh after 8 seconds.
                          </div>

                          <div class="alert alert-danger" id="danger" style="display:none;">
                               The User was NOT successfully Created, chat with Admin. Manage Users will start afresh after 8 seconds.
                          </div>
                         
                    
                          <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinner" >
                                 <img src="img/loading.gif" />
                                     Saving User........
                                 <img src="img/loader7.gif" />
                                                      
                          </div> 
                  
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnSave" value="Save" class="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

    <div class="modal inmodal" id="myModal3" tabindex="-1" role="dialog" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content animated flipInY">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Edit Users</h4>

                </div>


                <div class="modal-body">
                    <div class="ibox-content">
                        <div class="form-horizontal">
                           
                            <div class="form-group">
                                <label class="col-lg-3 control-label">User Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtUsername1" runat="server" CssClass="form-control" placeholder="User Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">First Name: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtFirstName1" runat="server" CssClass="form-control" placeholder="First Name"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Surname: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtSurname1" runat="server" CssClass="form-control" placeholder="Surname"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Password: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtPassword1" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Confirm Password: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtConfirmPassword1" runat="server" CssClass="form-control" placeholder="Confirm Password" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Phone Number: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtPhone1" runat="server" CssClass="form-control" placeholder="Phone Number" ></asp:TextBox>
                                </div>
                            </div>
                            
                            <div class="form-group">
                                <label class="col-lg-3 control-label">Email Address: </label>
                                <div class="col-lg-9">
                                    <asp:TextBox ID="txtEmail1" runat="server" CssClass="form-control" placeholder="Email Address"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-lg-3 control-label">Current Passport: </label>
                                <div class="col-lg-9">
                                    <asp:Image ID="imgAdminPicture" runat="server" style="width: 200px; height: 150px;"></asp:Image>
                                </div>
                            </div>

                             <div class="form-group">
                                <label class="col-lg-3 control-label">Passport Photography: </label>
                                   <div class="col-lg-9">
                                     <div class="panel panel-success" menuitemname="Client Shortcuts">
                                                <div class="panel-heading">
                                                    <h3 class="panel-title"><i class="fa fa-bookmark"></i>&nbsp;Image Capturing</h3>
                                                </div>
                                                <div>&nbsp;</div>
                                                <div style="padding: 0 10px 0 10px;">
                                                    <div class="fileinput fileinput-new" data-provides="fileinput">
                                                        <div class="fileinput-preview thumbnail" data-trigger="fileinput" style="width: 200px; height: 150px;"></div>
                                                        <div>
                                                            <span class="btn btn-success btn-file"><span class="fileinput-new">Select Student Passport</span>
                                                                <span class="fileinput-exists">Change</span>
                                                                <asp:FileUpload ID="fileupload2" runat="server" required /></span>
                                                            <a href="#" class="btn btn-default fileinput-exists" data-dismiss="fileinput">Remove</a>
                                                        </div>
                                                </div>
                                          </div>
                                    </div>
                                </div>
                          </div>

                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    
                          <div class="alert alert-success" id="successEdit" style="display:none;">
                               The User was successfully Updated. Manage Users will start afresh after 8 seconds.
                          </div>

                          <div class="alert alert-danger" id="dangeEdit" style="display:none;">
                               The User was NOT successfully Updated, chat with Admin. Manage Users will start afresh after 8 seconds.
                          </div>
                          
                        <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerEdit" >
                                 <img src="img/loading.gif" />
                                    Editing Users......
                                 <img src="img/loader7.gif" />
                                                      
                          </div> 

                     <div class="alert alert-success" id="successDelete" style="display:none;">
                               The User was successfully Deleted. Manage Users will start afresh after 8 seconds.
                          </div>

                          <div class="alert alert-danger" id="dangeDelete" style="display:none;">
                               The User was NOT successfully Deleted, chat with Admin. Manage Users will start afresh after 8 seconds.
                          </div>
                          
                        <div class="col-lg-12" style="color:#F25926; font-size:15px; display: none; text-align:center;" id="spinnerDelete" >
                                 <img src="img/loading.gif" />
                                    Deleting Users......
                                 <img src="img/loader7.gif" />
                                                      
                          </div> 
                  
                    <button type="button" class="btn btn-white" data-dismiss="modal">Close</button>
                    <input type="button" id="btnEdit" value="Edit" class="btn btn-primary" />
                    <input type="button" id="btnDelete" value="Delete" class="btn btn-primary" />
                </div>


            </div>
        </div>
    </div>



    <%--New Implementation of jquery button submit--%>
    <script type="text/javascript" src="js/jquery-1.8.2.js"></script>
    <script type="text/javascript">
        //creating Users

        //Saving the data
        $(function () {
            $('#btnSave').click(function () {
                //Fetching the values of all the feilds
                //Step One
                var UserName = $("[id*=txtUserName]").val();
                var Surname = $("[id*=txtSurname]").val();
                var Firstname = $("[id*=txtFirstName]").val();
                var Password = $("[id*=txtPassword]").val();
                var Phone = $("[id*=txtPhone]").val();
                var Email = $("[id*=txtEmail]").val();

                //Checking if is filled
                if (UserName == '') {
                    alert('Please fill username to Continue')
                    return false;
                }

                //Checking if is filled
                if (Surname == '') {
                    alert('Please fill Surname to Continue')
                    return false;
                }

                //Checking if is filled
                if (Firstname == '') {
                    alert('Please fill First Name to Continue')
                    return false;
                }

                //Checking if is filled
                if (Password == '') {
                    alert('Please fill Password to Continue')
                    return false;
                }
                Email
                //Checking if is filled
                if (Phone == '') {
                    alert('Please fill Phone to Continue')
                    return false;
                }

                //Checking if is filled
                if (Email == '') {
                    alert('Please fill Email to Continue')
                    return false;
                }

                //Step Two
                var PhotoUrl = '';

                //var fileUpload = $("#fileupload1").get(0);
                var fileUpload = $("[id*=fileupload1]").get(0);
                var files = fileUpload.files;

                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }

                //Uploading passport
                $.ajax({
                    url: "adminFileUploader.ashx",
                    type: "POST",
                    data: data,
                    contentType: false,
                    processData: false,
                    success: function (result) {
                        //Getting the url of the Student's passport photography
                        PhotoUrl = result;

                        //Checking if passport is selected
                        if (PhotoUrl == '~/AdminPassport/') {
                            alert('Please Select your Passport Photography to Continue')
                            return false;
                        }

                        //Saving Student Data
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "ManageUser.aspx/InsertData",
                            data: "{'UserName':'" + UserName + "','Surname':'" + Surname + "','Firstname':'" + Firstname + "','Password':'" + Password + "','Phone':'" + Phone + "','Email':'" + Email + "','PhotoUrl':'" + PhotoUrl + "'}",
                            dataType: "json",
                            success: function (data) {
                                var obj = data.d;
                                if (obj != '') {
                                    //$("[id$='lblErroSuccess']").html(data.d);
                                    var check = data.d;
                                    if (check == 'success') {
                                        $('#success').show();
                                        setTimeout(function () { location.reload(); }, 8000);
                                    } else {
                                        $('#danger').show();
                                        setTimeout(function () { location.reload(); }, 8000);
                                    }

                                }

                                
                            },
                            beforeSend: function () {
                                // Code to display spinner
                                $('#spinner').show();
                            },
                            complete: function () {
                                // Code to hide spinner.
                                $('#spinner').hide();
                            },
                            error: function (result) {
                                alert('Error Occurred, Chat with Admin.');
                            }
                        });



                    },
                    error: function (err) {
                        alert(err.statusText)
                    }
                });

            })



            var essay_id = 1;
            var photoLink = '';
            var saltKeys = '';

            //Getting the primary key for deleting and updating
            $("a[data-toggle=modal]").click(function () {
                essay_id = $(this).attr('id');

                //Getting session that need to be updated
                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ManageUser.aspx/GetUsers",
                    data: "{'PID':'" + essay_id + "'}",
                    dataType: "json",
                    success: function (data) {

                        $("[id$='txtUsername1']").val(data.d[0]);
                        $("[id$='txtSurname1']").val(data.d[1]);
                        $("[id$='txtFirstName1']").val(data.d[2]);
                        $("[id$='txtPassword1']").val(data.d[3]);
                        $("[id$='txtConfirmPassword1']").val(data.d[3]);
                        $("[id$='txtPhone1']").val(data.d[4]);
                        $("[id$='txtEmail1']").val(data.d[5]);

                        var photo = data.d[6];
                        photoLink = data.d[6];
                        saltKeys = data.d[7];

                        var splitPhoto = photo.split("~");
                        var myPhoto = '..' + splitPhoto[1];

                        $('#<%=imgAdminPicture.ClientID%>').attr('src', myPhoto);

                    },
                    error: function (result) {
                        alert('Error. Chat with Admin');
                    }
                });

            });//End model popup


            $('#btnEdit').click(function () {
                var EditPID = essay_id;
                var SaltsKey = saltKeys;
                var photos = photoLink;


                //Fetching the values of all the feilds
                //Step One
                var UserNames = $("[id*=txtUsername1]").val();
                var Surname = $("[id*=txtSurname1]").val();
                var Firstname = $("[id*=txtFirstName1]").val();
                var Password = $("[id*=txtPassword1]").val();
                var Phone = $("[id*=txtPhone1]").val();
                var Email = $("[id*=txtEmail1]").val();

                ////Checking if is filled
                if (UserNames == '') {
                    alert('Please fill username to Continue')
                    return false;
                }

                //Checking if is filled
                if (Surname == '') {
                    alert('Please fill Surname to Continue')
                    return false;
                }

                //Checking if is filled
                if (Firstname == '') {
                    alert('Please fill First Name to Continue')
                    return false;
                }

                //Checking if is filled
                if (Password == '') {
                    alert('Please fill Password to Continue')
                    return false;
                }
               
                //Checking if is filled
                if (Phone == '') {
                    alert('Please fill Phone to Continue')
                    return false;
                }

                //Checking if is filled
                if (Email == '') {
                    alert('Please fill Email to Continue')
                    return false;
                }

                //Step Two
                var PhotoUrl = '';

                //var fileUpload = $("#fileupload1").get(0);
                var fileUpload = $("[id*=fileupload2]").get(0);
                var files = fileUpload.files;

                var data = new FormData();
                for (var i = 0; i < files.length; i++) {
                    data.append(files[i].name, files[i]);
                }

                //Uploading passport
                $.ajax({
                    url: "adminFileUploader.ashx",
                    type: "POST",
                    data: data,
                    contentType: false,
                    processData: false,
                    success: function (result) {
                        //Getting the url of the Student's passport photography
                        PhotoUrl = result;

                        //Checking if passport is selected
                        if (PhotoUrl == '~/AdminPassport/') {
                            PhotoUrl = photos;
                        }
                        
                        
                        //Saving Student Data
                        $.ajax({
                            type: "POST",
                            contentType: "application/json; charset=utf-8",
                            url: "ManageUser.aspx/UpdateData",
                            data: "{'EditPID':'" + EditPID + "','UserNames':'" + UserNames + "','Surname':'" + Surname + "','Firstname':'" + Firstname + "','Password':'" + Password + "','Phone':'" + Phone + "','Email':'" + Email + "','PhotoUrl':'" + PhotoUrl + "','SaltKey':'" + SaltsKey + "'}",
                            dataType: "json",
                            success: function (data) {
                                var obj = data.d;

                               

                                if (obj != '') {
                                    //$("[id$='lblErroSuccess']").html(data.d);
                                    var check = data.d;
                                    if (check == 'success') {
                                        $('#successEdit').show();
                                        setTimeout(function () { location.reload(); }, 8000);
                                    } else {
                                        $('#dangeEdit').show();
                                        setTimeout(function () { location.reload(); }, 8000);
                                    }

                                }


                            },
                            beforeSend: function () {
                                // Code to display spinner
                                $('#spinnerEdit').show();
                            },
                            complete: function () {
                                // Code to hide spinner.
                                $('#spinnerEdit').hide();
                            },
                            error: function (result) {
                                alert('Error Occurred, Chat with Admin.');
                            }
                        });



                    },
                    error: function (err) {
                        alert(err.statusText)
                    }
                });

            })//End of edit


            $('#btnDelete').click(function () {
                var EditPID = essay_id;


                $.ajax({
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    url: "ManageUser.aspx/DeleteData",
                    data: "{'EPID':'" + EditPID + "'}",
                    dataType: "json",
                    success: function (data) {
                         if (check == 'success') {
                                $('#successDelete').show();
                                setTimeout(function () { location.reload(); }, 8000);
                            } else {
                                $('#dangeDelete').show();
                                setTimeout(function () { location.reload(); }, 8000);
                            }

                    },
                    beforeSend: function () {
                        // Code to display spinner
                        $('#spinnerDelete').show();
                    },
                    complete: function () {
                        // Code to hide spinner.
                        $('#spinnerDelete').hide();
                    },
                    error: function (result) {
                        alert('Error, chat with admin.');
                    }
                });
            })//Ending Delete



        });

    </script>


             
 <!-- Mainly scripts -->
        <script src="js/jquery-2.1.1.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
        <script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>
        <script src="js/plugins/jeditable/jquery.jeditable.js"></script>

        <script src="js/plugins/dataTables/datatables.min.js"></script>

        <!-- Custom and plugin javascript -->
        <script src="js/inspinia.js"></script>
        <script src="js/plugins/pace/pace.min.js"></script>


   <!-- Steps -->
    <script src="js/plugins/staps/jquery.steps.min.js"></script>

    <!-- Jquery Validate -->
    <script src="js/plugins/validate/jquery.validate.min.js"></script>

    <!-- Chosen -->
    <script src="js/plugins/chosen/chosen.jquery.js"></script>

   <!-- JSKnob -->
   <script src="js/plugins/jsKnob/jquery.knob.js"></script>

   <!-- Input Mask-->
    <script src="js/plugins/jasny/jasny-bootstrap.min.js"></script>

   <!-- Data picker -->
   <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

   <!-- NouSlider -->
   <script src="js/plugins/nouslider/jquery.nouislider.min.js"></script>

   <!-- Switchery -->
   <script src="js/plugins/switchery/switchery.js"></script>

    <!-- IonRangeSlider -->
    <script src="js/plugins/ionRangeSlider/ion.rangeSlider.min.js"></script>

    <!-- iCheck -->
    <script src="js/plugins/iCheck/icheck.min.js"></script>

    <!-- MENU -->
    <script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>

    <!-- Color picker -->
    <script src="js/plugins/colorpicker/bootstrap-colorpicker.min.js"></script>

    <!-- Clock picker -->
    <script src="js/plugins/clockpicker/clockpicker.js"></script>

    <!-- Image cropper -->
    <script src="js/plugins/cropper/cropper.min.js"></script>

    <!-- Date range use moment.js same as full calendar plugin -->
    <script src="js/plugins/fullcalendar/moment.min.js"></script>

    <!-- Date range picker -->
    <script src="js/plugins/daterangepicker/daterangepicker.js"></script>

    <!-- Select2 -->
    <script src="js/plugins/select2/select2.full.min.js"></script>

    <!-- TouchSpin -->
    <script src="js/plugins/touchspin/jquery.bootstrap-touchspin.min.js"></script>


    <script>
        $(document).ready(function () {

            var $image = $(".image-crop > img")
            $($image).cropper({
                aspectRatio: 1.618,
                preview: ".img-preview",
                done: function (data) {
                    // Output the result data for cropping image.
                }
            });

            var $inputImage = $("#inputImage");
            if (window.FileReader) {
                $inputImage.change(function () {
                    var fileReader = new FileReader(),
                            files = this.files,
                            file;

                    if (!files.length) {
                        return;
                    }

                    file = files[0];

                    if (/^image\/\w+$/.test(file.type)) {
                        fileReader.readAsDataURL(file);
                        fileReader.onload = function () {
                            $inputImage.val("");
                            $image.cropper("reset", true).cropper("replace", this.result);
                        };
                    } else {
                        showMessage("Please choose an image file.");
                    }
                });
            } else {
                $inputImage.addClass("hide");
            }

            $("#download").click(function () {
                window.open($image.cropper("getDataURL"));
            });

            $("#zoomIn").click(function () {
                $image.cropper("zoom", 0.1);
            });

            $("#zoomOut").click(function () {
                $image.cropper("zoom", -0.1);
            });

            $("#rotateLeft").click(function () {
                $image.cropper("rotate", 45);
            });

            $("#rotateRight").click(function () {
                $image.cropper("rotate", -45);
            });

            $("#setDrag").click(function () {
                $image.cropper("setDragMode", "crop");
            });
        });
</script>
        <!-- Page-Level Scripts -->
        <script>
            $(document).ready(function () {
                $('.dataTables-example').DataTable({
                    dom: '<"html5buttons"B>lTfgitp',
                    buttons: [
                        { extend: 'copy' },
                        { extend: 'csv' },
                        { extend: 'excel', title: 'ExampleFile' },
                        { extend: 'pdf', title: 'ExampleFile' },

                        {
                            extend: 'print',
                            customize: function (win) {
                                $(win.document.body).addClass('white-bg');
                                $(win.document.body).css('font-size', '10px');

                                $(win.document.body).find('table')
                                        .addClass('compact')
                                        .css('font-size', 'inherit');
                            }
                        }
                    ]

                });

                /* Init DataTables */
                var oTable = $('#editable').DataTable();

                /* Apply the jEditable handlers to the table */
                oTable.$('td').editable('http://webapplayers.com/example_ajax.php', {
                    "callback": function (sValue, y) {
                        var aPos = oTable.fnGetPosition(this);
                        oTable.fnUpdate(sValue, aPos[0], aPos[1]);
                    },
                    "submitdata": function (value, settings) {
                        return {
                            "row_id": this.parentNode.getAttribute('id'),
                            "column": oTable.fnGetPosition(this)[2]
                        };
                    },

                    "width": "90%",
                    "height": "100%"
                });


            });

            function fnClickAddRow() {
                $('#editable1').dataTable().fnAddData([
                    "Custom row",
                    "New row",
                    "New row",
                    "New row",
                    "New row"]);

            }
        </script>
</asp:Content>

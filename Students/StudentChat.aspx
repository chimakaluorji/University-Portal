<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentChat.aspx.vb" Inherits="StudentChat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <!-- Toastr style -->
    <link href="css/plugins/toastr/toastr.min.css" rel="stylesheet">

    <!-- Gritter -->
    <link href="js/plugins/gritter/jquery.gritter.css" rel="stylesheet">

    <link href="css/plugins/dataTables/datatables.min.css" rel="stylesheet">

 
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


<div class="wrapper wrapper-content animated fadeInRight">
       <div class="row">
          <div class="col-lg-12">
            <div class="span10">
                <asp:Label ID="lblError" runat="server" Text="" Font-Bold="true" Font-Size="15px"></asp:Label>
            </div>

            <div class="row-fluid sortable">
				        <div class="box span12">   
                    <div class="ibox-title">
                        <small class="pull-right text-muted">Last message:  Mon Jan 26 2015 - 18:39:23</small>
                         <b>Chat Room Panel</b>
                    </div>
					<div class="ibox-content">

                        <div class="row">

                            <div class="col-md-9 ">
                                <div class="chat-discussion" id="chat-discussion">

                                </div>

                            </div>
                            <div class="col-md-3">
                                <div class="chat-users">


                                    <div class="users-list" id="users-list">

                                    </div>

                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="chat-message-form">

                                    <div class="form-group">

                                        <textarea class="form-control message-input" name="message" placeholder="Enter message text" id="txtMsgBox" height="10px"></textarea>
                                    </div>

                                </div>
                            </div>
                        </div>
                        
                        <%-- <div class="ibox-title">--%>
                            <small class="pull-right text-muted">
                                <input type="button" id="btnSend" value="Send" class="btn btn-primary" />
                                <%--<asp:Button ID="Button1" runat="server" Text="Button" />
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>
                            </small>
                        <%--</div>--%>

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
 
        //Page loading all chat
        load_all_chat();

        //Loading all student online
        //load_All_Admin_Online();

        //Sending Message
        $('#btnSend').click(function () {
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var UserID = '<%= Request.QueryString("UserID")%>';

            var msg = $('#txtMsgBox').val();
            var regNumber = '<%= Request.QueryString("RegNumber")%>';
            

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentChat.aspx/InsertChat",
                data: "{'Emsg':'" + msg + "','Edate':'" + date + "','Etime':'" + time + "','newUserID':'" + UserID + "','regNumber':'" + regNumber + "'}",
                dataType: "json",
                success: function (data) {
                    
                    var leftMsg = "";
                    var rightMsg = "";
                    var photo = data.d[0].StudentPhotoUrl;
                    
                    var newArrayPhoto = photo.split("/");
                    var newPhoto = "../" + newArrayPhoto[1] + '/' + newArrayPhoto[2];

                    var StudentName = data.d[0].StudentName;
                    

                    leftMsg = "<div class='chat-message right' id='right'> <img class='message-avatar' src='" + newPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + StudentName + " </a><span class='message-date'>" + time + "</span><span class='message-content'>" + msg + "</span></div></div>";

                    var div = $(leftMsg + rightMsg);
                    $("#chat-discussion").append(leftMsg);

                    $('#txtMsgBox').val('');


                    //Ensuring the scroll bar is at the bottom
                    $("#chat-discussion").animate({ scrollTop: $('#chat-discussion').prop("scrollHeight") }, 1000);
                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });
           

        });// Sending Message Ends here

       

        //Pressing Enter Key
        $('#txtMsgBox').keypress(function (e) {
            if (e.which == 13) {
                $("#btnSend").click();
                e.preventDefault();
            }
        });
        //End of Pressing Enter Key


        //Knowing when a message is read
        jQuery('#txtMsgBox').on('input', function () {
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var UserID = '<%= Request.QueryString("UserID")%>';

            var regNumber = '<%= Request.QueryString("RegNumber")%>';

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentChat.aspx/ReadMessageStudent",
                data: "{'newUserID':'" + UserID + "','Eregno':'" + regNumber + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });
        });



        //Reloading admin online
        setInterval(load_All_Admin_Online, 1000);

        function load_All_Admin_Online() {
            //Loading Student Online
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentChat.aspx/GetAdminOnline",
                data: "{}",
                dataType: "json",
                success: function (data) {

                    var chatPanel = "";
                    var photoUrl = "";

                    $("#users-list").empty();

                    var reg = '<%= Request.QueryString("RegNumber").Trim%>';

                    for (var i = 0; i < data.d.length; i++) {

                        photoUrl = data.d[i].PhotoUrl;
                        var newArrayPhoto = photoUrl.split("/");
                        var newPhoto = "../" + newArrayPhoto[1] + '/' + newArrayPhoto[2];
                        msgCount = data.d[i].MsgCount;
                        

                        chatPanel = "<div class='chat-user'><span class='pull-right label label-primary'> " + msgCount + " </span><img class='chat-avatar' src='" + newPhoto + "' alt='' ><div class='chat-user-name'> <a href='StudentChat.aspx?RegNumber=" + reg + "&UserID=" + data.d[i].UserID + "'>" + data.d[i].AdminName + "</a></div></div>";

                        $("#users-list").append(chatPanel);

                    }

                },
                error: function (result) {
                   // alert('Something went wrong.');
                }
            }); //End of Loading student online
        }


        //Reloading admin_Chat function in every 1 second
         setInterval(admin_chat, 1000);
       
        //Creating Function that load admin chat
       var ChatID = 0;

      function admin_chat() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var UserID = '<%= Request.QueryString("UserID")%>';


            if (UserID != '') {
                newUserID = UserID
            } else {
                newUserID = intUserID
            }

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentChat.aspx/GetAdminChat",
                data: "{'newUserID':'" + UserID + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var leftMsg = "";
                    var rightMsg = "";
                    var dbChatID = 0;

                    //Handling audio
                    var audiot = new Audio("../ChatSound/sound.mp3");

                    dbChatID = data.d[0].ChatID;

                    userPhoto = data.d[0].UserPhotoUrl;

                    var newArrayuserPhoto = userPhoto.split("/");
                    var newuserPhoto = "../" + newArrayuserPhoto[1] + '/' + newArrayuserPhoto[2];

                    

                    if (dbChatID > ChatID) {
                        leftMsg = "<div class='chat-message left' id='left'> <img class='message-avatar' src='" + newuserPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[0].UserName + " </a><span class='message-date'>" + data.d[0].UserTime + "</span><span class='message-content'>" + data.d[0].UserMsg + "</span></div></div>";
                        ChatID = dbChatID

                        audiot.play();
                        //audiot.pause();
                       
                    } //End if statement for checking if message was sent


                    var div = $(leftMsg);
                    $("#chat-discussion").append(div);

                    $("#chat-discussion").animate({ scrollTop: $('#chat-discussion').prop("scrollHeight") }, 1000);
                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });
            //Sending Message Ends here
        }


  //Creating a reload function
   function load_all_chat() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            var regno = '<%=Request.QueryString("RegNumber")%>';

            var UserID = '<%= Request.QueryString("UserID")%>';

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentChat.aspx/GetAllChat",
                data: "{'newUserID':'" + UserID + "','Eregno':'" + regno + "','Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var checkUserMsg = "";
                    var checkStudentMsg = "";
                    var leftMsg = "";
                    var rightMsg = "";

                    for (var i = 0; i < data.d.length; i++) {
                        checkUserMsg = data.d[i].UserMsg;
                        checkStudentMsg = data.d[i].StudentMsg;
                        userPhoto = data.d[i].UserPhotoUrl;
                        studentPhoto = data.d[i].StudentPhotoUrl;

                        var newArrayuserPhoto = userPhoto.split("/");
                        var newuserPhoto = "../" + newArrayuserPhoto[1] + '/' + newArrayuserPhoto[2];

                        var newArraystudentPhoto = studentPhoto.split("/");
                        var newstudentPhoto = "../" + newArraystudentPhoto[1] + '/' + newArraystudentPhoto[2];

                        if (checkStudentMsg != '') {
                            leftMsg = "<div class='chat-message right' id='right'> <img class='message-avatar' src='" + newstudentPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[i].StudentName + " </a><span class='message-date'>" + data.d[i].StudentTime + "</span><span class='message-content'>" + data.d[i].StudentMsg + "</span></div></div>";
                        }

                        if (checkUserMsg != '') {
                            rightMsg = "<div class='chat-message left' id='left'> <img class='message-avatar' src='" + newuserPhoto + "' alt='' ><div class='message'><a class='message-author' href='#'> " + data.d[i].UserName + " </a><span class='message-date'>" + data.d[i].UserTime + "</span><span class='message-content'>" + data.d[i].UserMsg + "</span></div></div>";
                        }

                        var div = $(leftMsg + rightMsg);
                        $("#chat-discussion").append(div);
                    }

                    //Sending Message Ends here
                    $('#chat-discussion').animate({ scrollTop: $(document).height() }, 1500);

                },
                error: function (result) {
                    //alert('Something went wrong.');
                }
            });// closing ajax

        }

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
</asp:Content>
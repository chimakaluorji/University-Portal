<%@ Page Language="VB" MasterPageFile="~/Students/StudentMasterPage.master" AutoEventWireup="false" CodeFile="StudentAddCourse.aspx.vb" Inherits="Students_StudentAddCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="small-chat-box fadeInRight animated">
        
            <div class="heading" draggable="true">
                    <small class="chat-date pull-right">
                    <asp:Label ID="lblHeaderTime" runat="server" Text=""></asp:Label>

                    </small>
                    <asp:Label ID="lblHeaderName" runat="server" Text=""></asp:Label>
            </div>

            <div class="content" id="content">

            </div>

            <div class="form-chat">
                <div class="input-group input-group-sm">
                    
                    <input type="text" class="form-control" id="txtMsgBox">
                     
                      <span class="input-group-btn"> 
                        <input type="button" class="btn btn-primary" value="Send" id="btnSend">
                    </span>

                </div>
             </div>

        </div>


        <div id="small-chat">
            <span class="badge badge-warning pull-right">5</span>
            <a class="open-small-chat">
                <i class="fa fa-comments"></i>
            </a>
        </div>

    <%--New Implementation of jquery button submit--%>
<script type="text/javascript" src="js/jquery-1.8.2.js"></script>
<script type="text/javascript">

    $(function () {

        $('#small-chat').click(function (e) {  
            auto_load();
            //$('#content').animate({scrollTop: $(document).height()}, 1500);
        });

        //Sending Message
        $('#btnSend').click(function () {
            //Getting the message
            var msg = $('#txtMsgBox').val();
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            $("[id$='lblHeaderTime']").html(time);
            $("[id$='lblHeaderName']").html("Kaluorji Chima");


            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentAddCourse.aspx/InsertChat",
                data: "{'Emsg':'" + msg + "','Edate':'" + date + "','Etime':'" + time + "'}",
                dataType: "json",
                success: function (data) {
                    var leftMsg = "";
                    var rightMsg = "";

                    leftMsg = "<div class='left' id='left'><div class='author-name'> " + data.d[0].StudentName + " <small class='chat-date'> " + time + " </small></div><div class='chat-message active'> " + msg + " </div></div>";

                    var div = $(leftMsg + rightMsg);
                    $("#content").append(div);

                    $('#txtMsgBox').val('');


                },
                error: function (result) {
                    alert('Something went wrong.');
                }
            });
            //Sending Message Ends here

            //$("#content").scrollTop($("#content")[0].scrollHeight);
            //$('#content').scrollTop(1000000);

            $("#content").animate({ scrollTop: $('#content').prop("scrollHeight") }, 1000);
        });
        //End of Clicking Send Button

        


        //Pressing Enter Key
        $('#txtMsgBox').keypress(function (e) {
            if (e.which == 13) {
                $("#btnSend").click();
                e.preventDefault();
            }
        });
        //End of Pressing Enter Key

        //Creating a reload function
        function auto_load() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            $("[id$='lblHeaderTime']").html(time);
            $("[id$='lblHeaderName']").html("Kaluorji Chima");

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentAddCourse.aspx/GetChat",
                data: "{'Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var checkUserMsg = "";
                    var checkStudentMsg = "";
                    var leftMsg = "";
                    var rightMsg = "";

                    

                    for (var i = 0; i < data.d.length; i++) {
                        checkUserMsg = data.d[i].UserMsg;
                        checkStudentMsg = data.d[i].StudentMsg;

                        if (checkStudentMsg != '') {
                            leftMsg = "<div class='left'><div class='author-name'> " + data.d[i].StudentName + " <small class='chat-date'> " + data.d[i].StudentTime + " </small></div><div class='chat-message active'> " + data.d[i].StudentMsg + " </div></div>";
                        }

                        if (checkUserMsg != '') {
                            rightMsg = "<div class='right' id='right'><div class='author-name'> " + data.d[i].UserName + " <small class='chat-date'>" + data.d[i].UserTime + "</small></div><div class='chat-message'>" + data.d[i].UserMsg + "</div></div>";
                        }

                        var div = $(leftMsg + rightMsg);
                        $("#content").append(div);
                    }

                },
                error: function (result) {
                    alert('Something went wrong.');
                }
            });
            //Sending Message Ends here
            $('#content').animate({ scrollTop: $(document).height() }, 1500);
        }
        //End of function auto load

        
        //Creating a reload function
        var ChatID = 0;

        function admin_chat() {
            //Getting the message
            var dt = new Date();
            var date = dt.getDate() + '-' + dt.getMonth() + '-' + dt.getFullYear();
            var time = dt.getHours() + ':' + dt.getMinutes() + ':' + dt.getSeconds();

            $("[id$='lblHeaderTime']").html(time);
            $("[id$='lblHeaderName']").html("Kaluorji Chima");

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "StudentAddCourse.aspx/GetAdminChat",
                data: "{'Edate':'" + date + "'}",
                dataType: "json",
                success: function (data) {

                    var leftMsg = "";
                    var rightMsg = "";
                    var dbChatID = 0;

                    //Handling audio
                    //var audiot = new Audio("../ChatSound/sound.mp3");

                    dbChatID = data.d[0].ChatID;
                    if (dbChatID > ChatID) {
                        rightMsg = "<div class='right'><div class='author-name'> " + data.d[0].UserName + " <small class='chat-date'>" + data.d[0].UserTime + "</small></div><div class='chat-message'>" + data.d[0].UserMsg + "</div></div>";
                        ChatID = dbChatID

                        ////Play sound if the user is not active for 3 mins
                        //var idleTime = 0;

                        ////Increment the idle time counter every minute.
                        //var idleInterval = setInterval(timerIncrement, 60000); // 1 minute

                        ////Zero the idle timer on mouse movement.
                        //$(this).mousemove(function (e) {
                        //    idleTime = 0;
                        //});
                        //$(this).keypress(function (e) {
                        //    idleTime = 0;
                        //});


                        //function timerIncrement() {
                        //    idleTime = idleTime + 1;
                        //    if (idleTime > 2) { // 3 minutes
                        //        audiot.play();
                        //        audiot.pause();
                        //    }
                        //}
                    }

                    var div = $(rightMsg);
                    $("#content").append(div);


                },
                error: function (result) {
                    alert('Something went wrong.');
                }
            });
            //Sending Message Ends here
            $("#content").animate({ scrollTop: $('#content').prop("scrollHeight") }, 1000);
        }

        //Refresh auto_load() function after half a second
        setInterval(admin_chat, 1000);
    });


    </script>


</asp:Content>
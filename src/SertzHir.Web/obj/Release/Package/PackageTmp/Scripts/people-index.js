$(document).ready(function () {

    //Retrieve States
    $.ajax({
        method: "GET"
        , url: '@Url.RouteUrl(MvcRoutes.StatesListAllRouteName)'
        , dataType: "json"
        , success: function (data) {
            $.each(data, function (index, item) {
                $(" #addPersonModal #StateId").append($("<option value='" + item.StateId + "'>" + item.StateCode + " </option>"));

                $(" #editPersonModal #StateId").append($("<option value='" + item.StateId + "'>" + item.StateCode + " </option>"));

            });

        }
        , error: function (jqXHR, textStatus, errorThrown) {
            $("#divPersonModalAlert").show();
            $("#divPersonModalAlert").html(errorThrown);
        }
    });


    //Bind Edit Button
    $(".btn-edit").click(function (e) {
        $("#editPersonModal").modal('show');

        //Get the Person Record
        $.ajax({
            method: "GET"
            , url: '@Url.RouteUrl(MvcRoutes.PersonGetByIdRouteName)'
            , dataType: "json"
            , data: {
                "id": $(this).attr("data-id")
            }
            , success: function (data) {

                var dob = moment(data.DateOfBirth).format('YYYY-MM-DD');
                $(" #formEditPerson #PersonId").val(data.PersonId);
                $(" #formEditPerson #LastName").val(data.LastName);
                $(" #formEditPerson #FirstName").val(data.FirstName);
                $(" #formEditPerson #Gender").val(data.Gender);
                $(" #formEditPerson #DateOfBirth").val(dob);
                $(" #formEditPerson #StateId").val(data.StateId);

            }
            , error: function (jqXHR, textStatus, errorThrown) {
                $("#divPersonModalAlert").show();
                $("#divPersonModalAlert").html(errorThrown);
            }
        });

    });

    //Bind Search button
    $("#formSearch").submit(function (e) {
        e.preventDefault();
        //Get the list of people
        $.ajax({
            method: "GET"
            , url: '@Url.RouteUrl(MvcRoutes.PeopleListRouteName)'
            , dataType: "json"
            , data: {
                "firstName": $("#txtSearchFirstName").val()
                , "lastName": $("#txtSearchLastName").val()
            }
            , success: function (data) {
                $("#tbodyPeople").html("");
                $.each(data, function (index, item) {
                    var dob = moment(item.DateOfBirth).format('YYYY-MM-DD');
                    $("#tbodyPeople").append(
                        "<tr>"
                        + "<td scope='row'>"
                        + item.LastName
                        + "</td>"
                        + "<td scope='row'>"
                        + item.FirstName
                        + "</td>"
                        + "<td scope='row'>"
                        + item.Gender
                        + "</td>"
                        + "<td scope='row'>"
                        + dob
                        + "</td>"
                        + "<td scope='row'>"
                        + item.StateCode
                        + "</td>"
                        + "<td>"
                        + "<div class='container-fluid'>"
                        + "<button class='btn btn-info btn-edit' type='button' data-id='" + item.PersonId + "'><span class='fa fa-edit'></span>&nbsp;Edit</button>&nbsp;"
                        + "</div>"
                        + "</td>"
                        + "</tr>"
                    );
                });

            }
            , error: function (jqXHR, textStatus, errorThrown) {
                $("#divPersonModalAlert").show();
                $("#divPersonModalAlert").html(errorThrown);
            }
        });

    });




});
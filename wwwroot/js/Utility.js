function dPicker(name) {
    $("#" + name + "").persianDatepicker({
        cellWidth: 43,
        cellHeight: 23,
        fontSize: 15,
        selectedBefore: !0,
        formatDate: "YYYY/0M/0D",
    });
}
function FormSerialize(form, Type) {
    if (Type == "Create") {
        var data = $("#" + form).serializeArray();
        var obj = {};
        for (var i = 0; i < data.length; i++) {
            obj[data[i].name] = data[i].value;
        }
        return obj;
    }
    else if (Type == "Edit") {
        var data = $("#" + form).serializeArray();
        var obj = {};
        for (var i = 0; i < data.length; i++) {
            obj[data[i].name.replace("Edit", "")] = data[i].value;
        }
        return obj;
    }
    else {
        DevErrorMessage();
    }
}
//Check Form Validation
function CheckFormValidation(form) {
    var IsValid = true;
    var myForm = document.forms[form].getElementsByTagName("input");
    var myForm2 = document.forms[form].getElementsByTagName("select");
    var temp = {};
    var data = [];
    for (var i = 0; i < myForm.length; i++) {
        temp.id = myForm[i].id;
        temp.value = myForm[i].value;
        temp.type = myForm[i].type;
        data.push(temp);
        temp = {};
    }
    //Check Validation
    for (var i = 0; i < data.length; i++) {
        if (data[i].type == "text" || data[i].type == "password") {
            if (document.getElementById(data[i].id).getAttribute('data-required') == 'true') {
                if (data[i].value.trim() == "") {
                    CreateValidation("S" + data[i].id, document.getElementById(data[i].id).getAttribute('data-message'));
                    IsValid = false;
                }
                else {
                    if (data[i].type == 'password') {
                        if (data[i].value.length < 8) {
                            CreateValidation("S" + data[i].id, "کلمه عبور وارد شده معتبر نیست");
                            IsValid = false;
                        }
                        else {
                            RemoveValidation("S" + data[i].id);
                            IsValid = true;
                        }
                    }
                }
            }
        }
    }
    return IsValid;
}

function CreateTable(TableID) {
    $("#" + TableID + "").DataTable({
        language: {
            search: "جستجو:",
            emptyTable: "رکوردی یافت نشد!",
            zeroRecords: "رکوردی یا فت نشد!",
            info: "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
            infoEmpty: "رکوردی یافت نشد!",
            processing: "در حال پردازش...",
            loadingRecords: "در حال بارگزاری...",
            lengthMenu: "نمایش _MENU_ رکورد",
            paginate: {
                first: "اولین",
                last: "آخرین",
                next: "بعدی",
                previous: "قبلی"
            },
        },
        "info": true,
    });
}
//Handle Combobox
function HandleCombo(ValueID, ValueName, List, TagName, Type) {
    var str = '';
    if (Type == "Create") {
        str += '<option value=' + ValueID + '>' + ValueName + '</option>';
        for (var i = 0; i < List.length; i++) {
            str += '<option value=' + List[i].value + '>' + List[i].text + '</option>';
        }
    }
    else if (Type == "Edit") {
        str += '<option value=' + ValueID + '>' + ValueName + '</option>';
        for (var i = 0; i < List.length; i++) {
            if (List[i].value != ValueID) {
                str += '<option value=' + List[i].value + '>' + List[i].text + '</option>';
            }
        }
    }
    else if (Type == "Multi") {
        for (var i = 0; i < List.length; i++) {
            if (List[i].value != ValueID) {
                str += '<option value=' + List[i].value + '>' + List[i].text + '</option>';
            }
        }
    }
    else if (Type == "Single") {
        if (ValueName == true) {
            ValueName = "بله";
        }
        else if (ValueName == false) {
            ValueName = "خیر";
        }
        else {
            ValueName = ValueName;
        }
        str += '<option value=' + ValueID + '>' + ValueName + '</option>';
    }
    else {
        DevErrorMessage();
    }
    $("#" + TagName).html(str);
}
//Handle Location
function HandleLocation(data) {
    window.location.href = data;
}
//validate mask
function MCodeMeli(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "mask": "9999999999",
        "regext": "/^\d{10}$/"
    }).mask(selector);
}
function MMoaref(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "mask": "999999",
        "regext": "/^\d{10}$/"
    }).mask(selector);
}
function MVazn(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "mask": "999",
        "regext": "/^\d{10}$/"
    }).mask(selector);
}
function MMobile(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "mask": "99999999999",
        regex: "^[0-9]{2}:[0-5][0-9]:[0-5][0-9]$"
    }).mask(selector);
}
function MNumber(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "alias": "numeric"
    }).mask(selector);
}
function MSaat(TagID) {
    var selector = document.getElementById(TagID);
    Inputmask({
        "mask": "99:99"
    }).mask(selector);
}
//DataTable 
function MDataTable(TableID, Data, Columns, HideTarget, CoustomCellTarget, Buttons) {
    $("#" + TableID).dataTable().fnDestroy();
    $("#" + TableID).DataTable({
        data: Data,
        language: {
            search: "جستجو:",
            emptyTable: "رکوردی یافت نشد!",
            zeroRecords: "رکوردی یا فت نشد!",
            info: "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
            infoEmpty: "رکوردی یافت نشد!",
            processing: "در حال پردازش...",
            loadingRecords: "در حال بارگزاری...",
            lengthMenu: "نمایش _MENU_ رکورد",
            paginate: {
                first: "اولین",
                last: "آخرین",
                next: "بعدی",
                previous: "قبلی"
            },
        },
        autoWidth: false,
        columns: Columns,
        scrollX: true,
        fixedHeader: {
            header: true,
            footer: false,
            headerOffset: 45
        },
        columnDefs: [
            {
                targets: [HideTarget],
                visible: false,
                orderable: false,
                searchable: false,
                defaultContent: ''
            },
            {
                targets: ["_all"],
                className: "text-center"
            },
            {
                targets: [CoustomCellTarget],
                searchable: false,
                orderable: false,
                defaultContent: '',
                'createdCell': function (td, cellData, rowData, row, col) {
                    if (rowData.isDown) {
                        $(td).addClass("bg-success");
                    }
                    var str = '';
                    if ('Remove' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Remove + '(' + rowData.id + ')" class="btn btn-danger my-icon" title="حذف"><span class="fa fa-trash"></span></button>'
                    }
                    if ('Cansel' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Cansel + '(' + rowData.id + ')" class="btn btn-danger my-icon" title="لغو"><span class="fa fa-ban"></span></button>'
                    }
                    if ('Edit' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Edit + '(' + rowData.id + ')" class="btn btn-warning my-icon" title="ویرایش"><span class="fa fa-pen"></span></button>'
                    }
                    if ('List' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.List + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="لیست"><span class="fa fa-list"></span></button>'
                    }
                    if ('UserDitails' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.UserDitails + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="جزئیات"><span class="fa fa-id-card"></span></button>'
                    }
                    if ('MoneyDitails' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.MoneyDitails + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="جزئیات"><span class="fa fa-coins"></span></button>'
                    }
                    if ('MoneyDitails3' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.MoneyDitails3 + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="جزئیات"><span class="glyphicon glyphicon-usd"></span></button>'
                    }
                    if ("Select" in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Select + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="انتخاب"><span class="fa fa-hand-pointer"></span></button>'
                    }
                    if ("DoctorCheck" in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.DoctorCheck + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="معاینه"><span class="fa fa-stethoscope"></span></button>'
                    }
                    if ('Daru' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Daru + '(' + rowData.id + ')" class="btn btn-warning my-icon"  title="نسخه"><span class="fa fa-syringe"></span></button>'
                    }
                    if ('Azmayesh' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Azmayesh + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="آزمایش"><span class="fa fa-flask"></span></button>'
                    }
                    if ('CityScan' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.CityScan + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="سیتی اسکن"><span class="fa fa-camera"></span></button>'
                    }
                    if ('More' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.More + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="موارد بیشتر"><span class="fa fa-folder-plus"></span></button>'
                    }
                    if ('List3' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.List3 + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="لیست"><span class="glyphicon glyphicon-list"></span></button>'
                    }
                    if ('UserPlus' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.UserPlus + '(' + rowData.id + ')" class="btn btn-info my-icon"  title=""><span class="fa fa-user-plus"></span></button>'
                    }
                    if ('Document' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Document + '(' + rowData.id + ')" class="btn btn-warning my-icon"  title="پرونده "><span class="fa fa-folder"></span></button>'
                    }
                    if ('LinkFile' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.LinkFile + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="فایل پیوست "><span class="fa fa-paperclip"></span></button>'
                    }
                    if ('Confirm' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Confirm + '(' + rowData.id + ')" class="btn btn-success my-icon"  title="تایید"><span class="fa fa-check "></span></button>'
                    }
                    if ('Print' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Print + '(' + rowData.id + ')" class="btn btn-success my-icon"  title="چاپ"><span class="fa fa-print "></span></button>'
                    }
                    if ('UserInjured' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.UserInjured + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="عمل"><span class="fa fa-user-injured "></span></button>';
                    }
                    str += '';
                    $(td).html(str);
                }
            }
        ]
    });
}
function MDataTableCustom(TableID, Data, Columns, HideTarget, CoustomCellTarget, Buttons) {
    $("#" + TableID).dataTable().fnDestroy();
    $("#" + TableID).DataTable({
        data: Data,
        language: {
            search: "جستجو:",
            emptyTable: "رکوردی یافت نشد!",
            zeroRecords: "رکوردی یا فت نشد!",
            info: "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
            infoEmpty: "رکوردی یافت نشد!",
            processing: "در حال پردازش...",
            loadingRecords: "در حال بارگزاری...",
            lengthMenu: "نمایش _MENU_ رکورد",
            paginate: {
                first: "اولین",
                last: "آخرین",
                next: "بعدی",
                previous: "قبلی"
            },
        },
        autoWidth: false,
        columns: Columns,
        scrollX: true,
        columnDefs: [
            {
                targets: [HideTarget],
                visible: false,
                orderable: false,
                searchable: false,
                defaultContent: ''
            },
            {
                targets: [1],
                width: '20%'
            },
            {
                targets: ["_all"],
                className: "text-center"
            },
            {
                targets: [CoustomCellTarget],
                searchable: false,
                orderable: false,
                width: "200px",
                defaultContent: '',
                'createdCell': function (td, cellData, rowData, row, col) {
                    if (rowData.isDown) {
                        $(td).addClass("bg-success");
                    }
                    var str = '';
                    if ('Remove' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Remove + '(' + rowData.id + ')" class="btn btn-danger my-icon" title="حذف"><span class="fa fa-trash"></span></button>'
                    }
                    if ('Edit' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Edit + '(' + rowData.id + ')" class="btn btn-warning my-icon" title="ویرایش"><span class="fa fa-pen"></span></button>'
                    }
                    if ('List' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.List + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="لیست"><span class="fa fa-list"></span></button>'
                    }
                    if ('UserDitails' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.UserDitails + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="جزئیات"><span class="fa fa-id-card"></span></button>'
                    }
                    if ('MoneyDitails' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.MoneyDitails + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="جزئیات"><span class="fa fa-coins"></span></button>'
                    }
                    if ("Select" in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Select + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="انتخاب"><span class="fa fa-hand-pointer"></span></button>'
                    }
                    if ("DoctorCheck" in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.DoctorCheck + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="معاینه"><span class="fa fa-stethoscope"></span></button>'
                    }
                    if ('Daru' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Daru + '(' + rowData.id + ')" class="btn btn-warning my-icon"  title="نسخه"><span class="fa fa-syringe"></span></button>'
                    }
                    if ('Azmayesh' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Azmayesh + '(' + rowData.id + ')" class="btn btn-info my-icon"  title="آزمایش"><span class="fa fa-flask"></span></button>'
                    }
                    if ('CityScan' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.CityScan + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="سیتی اسکن"><span class="fa fa-camera"></span></button>'
                    }
                    if ('More' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.More + '(' + rowData.id + ')" class="btn btn-primary my-icon"  title="موارد بیشتر"><span class="fa fa-folder-plus"></span></button>'
                    }
                    if ('Document' in Buttons) {
                        str += '<button type="button" onclick="' + Buttons.Document + '(' + rowData.id + ')" class="btn btn-warning my-icon"  title="پرونده "><span class="fa fa-folder"></span></button>'
                    }
                    str += '';
                    $(td).html(str);
                }
            }
        ]
    });
}
//Validation Danger
function ShowBorder(input, info) {
    if (info == "danger") {
        document.getElementById(input).style.borderColor = "red";
    }
    else if (info == "normal") {
        document.getElementById(input).style.borderColor = "rgba(0, 0, 0, 0.15)";
    }
}
function CheckRequired(inputID, Type) {
    var data = document.getElementById(inputID).value;
    if (Type == "Select") {
        if (data != 0) {
            ShowBorder(inputID, "normal");
            return true;
        }
        else {
            ShowBorder(inputID, "danger");
            return false;
        }
    }
    else if (Type == "Input") {
        if (data != "") {
            ShowBorder(inputID, "normal");
            return true;
        }
        else {
            ShowBorder(inputID, "danger");
            return false;
        }
    }
    else {
        CustomError("مشکلی در اجرا رخ داد");
    }
}
function CreateValidation(SpanID, Text) {
    var span = document.getElementById(SpanID);
    span.innerHTML = Text;
    var InpId = SpanID.substring(1);
    ShowBorder(InpId, "danger");
    $(span).removeClass("d-none");
}
function RemoveValidation(SpanID) {
    var span = document.getElementById(SpanID);
    span.innerHTML = "";
    var InpId = SpanID.substring(1);
    ShowBorder(InpId, "normal");
    $(span).addClass("d-none");
}
function CheckNumberRegex(InputID) {
    var text = document.getElementById(InputID).value;
    const regex = RegExp("[0]{1}[9]{1}[0-9]{9}");
    if (regex.test(text)) {
        return true
    }
    else {
        return false;
    }
}
function CheckCodemeliRegex(InputID) {
    var input = document.getElementById(InputID).value;
    if (!/^\d{10}$/.test(input)
        || input == '0000000000'
        || input == '1111111111'
        || input == '2222222222'
        || input == '3333333333'
        || input == '4444444444'
        || input == '5555555555'
        || input == '6666666666'
        || input == '7777777777'
        || input == '8888888888'
        || input == '9999999999')
        return false;
    var check = parseInt(input[9]);
    var sum = 0;
    var i;
    for (i = 0; i < 9; ++i) {
        sum += parseInt(input[i]) * (10 - i);
    }
    sum %= 11;
    return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
}
function ProgressChanger(ID, Grow, Text) {
    document.getElementById(ID).style.width = Grow;
    $("#" + ID).text(Text);
}
//Form Creator
function FormCreator(ColSize, data, motherDiv) {
    var str = '';
    for (var i = 0; i < data.length; i++) {

        if (data[i].inputType == 'Input') {
            str += '<div class="col-lg-' + ColSize + '">';
            str += '<div class="form-group rtl">';
            str += '<label for=' + data[i].name + '>' + data[i].displayName + '&nbsp;را وارد کنید:</label>';
            str += '<input type="text" id=' + data[i].name + ' name=' + data[i].name + ' class="form-control" />';
            str += '</div>';
            str += '</div>';
        }
        else if (data[i].inputType == 'Select') {
            str += '<div class="col-lg-' + ColSize + '">';
            str += '<div class="form-group rtl">';
            str += '<label for="' + data[i].name + '">' + data[i].displayName + 'را انتخاب کنید</label>';
            str += '<select id=' + data[i].name + ' name=' + data[i].name + ' class="form-control"></select>';
            str += '</div>';
            str += '</div>';
        }
        else if (data[i].inputType == "Image") {
            str += '<div class="col-lg-' + ColSize + '">';
            str += '<div class="form-group rtl">';
            str += '<label for=' + data[i].name + '>' + data[i].displayName + '&nbsp;را انتخاب کنید:</label>';
            str += '<input accept="*/.jpg" type="file" id=' + data[i].name + ' name=' + data[i].name + ' class="form-control" />';
            str += '</div>';
            str += '</div>';
        }
    }
    for (var i = 0; i < data.length; i++) {
        if (data[i].inputType == "LongInput") {
            str += '<div class="col-lg-12">';
            str += '<div class="form-group rtl">';
            str += '<label for=' + data[i].name + '>' + data[i].displayName + '&nbsp;را وارد کنید:</label>';
            str += '<input type="text" id=' + data[i].name + ' name=' + data[i].name + ' class="form-control" />';
            str += '</div>';
            str += '</div>';
        }
    }
    $("#" + motherDiv).html(str);
}
//Check Repeat Password
function CheckPasswordRepeat(Pass, Repeat) {
    var IsValid;
    if (Pass == Repeat)
        IsValid = true;
    else
        IsValid = false;

    return IsValid;
}
function DestroyCombo(ID) {
    $("#" + ID + "").select2("val", "");
    $("#" + ID + "").trigger("reset");
    $("#" + ID + "").empty();
}
function CreateCombo(ID) {
    $("#" + ID + "").chosen({
        rtl: true,
        search_contains: true,
        width: "100%"
    });
}
//Message
function SuccessMessage() {
    Swal.fire({
        position: 'center',
        icon: 'success',
        title: 'عملیات با موفقیت انجام شد',
        showConfirmButton: false,
        timer: 1500
    })
}
function ConfirmDisable(id, url) {
    Swal.fire({
        title: 'مورد انتخابی غیر فعال شود؟',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: `بله حتما`,
        denyButtonText: `نه منصرف شدم!`,
    }).then((result) => {

        if (result.isConfirmed) {
            var form = document.createElement("form");
            var element = document.createElement("input");
            element.name = "Id";
            element.value = id;
            element.type = "hidden";
            form.appendChild(element);
            form.method = "Post";
            form.action = url;
            document.body.appendChild(form);
            form.submit();
        } else if (result.isDenied) {
            Swal.fire({
                position: 'center',
                icon: 'info',
                title: 'چیزی تغییر نکرد',
                showConfirmButton: false,
                timer: 1000
            })
        }
    })
}
function ConfirmEnable(id, url) {
    Swal.fire({
        title: 'مورد انتخابی  فعال شود؟',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: `بله حتما`,
        denyButtonText: `نه منصرف شدم!`,
    }).then((result) => {

        if (result.isConfirmed) {
            var form = document.createElement("form");
            var element = document.createElement("input");
            element.name = "Id";
            element.value = id;
            element.type = "hidden";
            form.appendChild(element);
            form.method = "Post";
            form.action = url;
            document.body.appendChild(form);
            form.submit();
        } else if (result.isDenied) {
            Swal.fire({
                position: 'center',
                icon: 'info',
                title: 'چیزی تغییر نکرد',
                showConfirmButton: false,
                timer: 1000
            })
        }
    })
}
function ConfirmRemove(id, url) {
    Swal.fire({
        title: 'مورد انتخابی حذف شود؟',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: `بله حتما`,
        denyButtonText: `نه منصرف شدم!`,
    }).then((result) => {
        if (result.isConfirmed) {
            var form = document.createElement("form");
            var element = document.createElement("input");
            element.name = "Id";
            element.value = id;
            element.type = "hidden";
            form.appendChild(element);
            form.method = "Post";
            form.action = url;
            document.body.appendChild(form);
            form.submit();
        } else if (result.isDenied) {
            Swal.fire({
                position: 'center',
                icon: 'info',
                title: 'چیزی تغییر نکرد',
                showConfirmButton: false,
                timer: 1000
            })
        }
    })
}
function NotFoundMessage() {
    Swal.fire({
        icon: 'error',
        title: 'خطا...',
        text: 'چیزی پیدا نشد!',
    })
}
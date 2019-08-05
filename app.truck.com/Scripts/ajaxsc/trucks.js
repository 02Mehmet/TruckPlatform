jQuery(document).ready(function () {
   
    jQuery("#drpBlockID").on("change", function () {
        var blokYeniID = jQuery("#drpBlockID").val();
        jQuery.ajax({
            url: '/Purse/GetFlatList/' + blokYeniID,
            dataType: "json",
            type: "GET",
            success: function (data) {
                var items = "";
                jQuery.each(data, function (i, item) {
                    items += "<option value=\"" + item.Id + "\">" + item.Ad + "</option>";
                });
                jQuery("#drpFlatID").html(items);
            }
        });
    });   
    jQuery("#AddNewTruck").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);

        var id = jQuery("#TruckID").val();
        var url;
        if (id !== null && id !== "") {
            url = "/Truck/TrucksEdit";
        }
        else {
            url = "/Truck/TrucksAdd";
        }
        jQuery.ajax({
            url: url,
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            dataType: 'json',
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                var jsonResult = data;
                var jsonModel = jsonResult.resultObject;
                jQuery(data).appendTo(jQuery("#tblTrucksList"));
            },
        });
        jQuery("#TruckID").val("");
    });
    jQuery("#frmDuesSearch").submit(function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var url = "/Purse/DuesSearch";
        debugger;
        jQuery.ajax({
            url: url,
            type: "POST",
            data: formData,
            mimeType: "multipart/form-data",
            dataType: 'json',
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                i = 1;
                var jsonResult = data;
                var jsonModel = jsonResult.resultObject;
                if (data != null) {
                    jQuery("#tblDuesList").find("tbody").html("");
                    jQuery.each(data, function (index, value) {
                        var html = '<tr data-id="' + (value.DuesID) + '">' +
                            '<td class="text-right bold">' + (i++) + '</td>' +
                            '<td >' + (value.MemberName == null ? "" : value.MemberName) + '</td>' +
                            '<td >' + (value.MonthName == null ? "" : value.MonthName) + '</td>' +
                            '<td class="text-center">' + (value.BlockName == null ? "" : value.BlockName) + '</td>' +
                            '<td class="text-center">' + (value.FlatName == null ? "" : value.FlatName) + '</td>' +
                            '<td >' + (value.SitMember == "1" ? "EV SAHİBİ" : "KİRACI") + '</td>' +
                            '<td class="text-center">' + (value.TransactionDateName == null ? "" : value.TransactionDateName) + '</td>' +
                            '<td class="font-red-soft font-lg bold text-right">' + value.Amount + ' ₺</td>' +
                            '<td class="text-center"><a id="DuesEdit" title="Düzelt" class="btn btn-outline btn-circle btn-sm green-haze" data-id="' + value.DuesID + '"> <i class="fa fa-edit"></i></a>' +
                            '<a id="DuesDelete" title="Sil"  class="btn btn-outline btn-circle dark btn-sm red" data-id="' + value.DuesID + '"><i class="fa fa-trash-o"></i></a></td>' +
                            '</tr>';
                        jQuery("#tblDuesList").find("tbody").append(html);
                    });
                }
            },
        });
    });
    jQuery("#tblTruckList").delegate("#TruckEdit", "click", function () {

        var id = jQuery(this).attr("data-id");
        jQuery("#TruckID").val(id);
        debugger;
        jQuery.ajax({
            url: "/Trucks/GetTruckByID",
            type: 'GET',
            data: 'id=' + id,
            contentType: false,
            cache: false,
            processData: false,
            success: function (data, textStatus, jqXHR) {
                jQuery("#PlateNumber").val(data.PlateNumber);
                jQuery("#ProcessTime").val(data.ProcessTime);
               
            }
        });
    });
    jQuery("#tblTruckList").delegate("#TruckDelete", "click", function () {
        var id = jQuery(this).attr("data-id");
        var confirmDelete = confirm("Seçili kaydı silmek istediğinizden emin misiniz ?");
        if (confirmDelete) {
            jQuery.ajax({
                url: "/Purse/DuesDelete",
                type: 'GET',
                data: 'id=' + id,
                contentType: false,
                cache: false,
                processData: false,
                success: function (data, textStatus, jqXHR) {
                    debugger;
                    var tr = jQuery("#tblDuesList").find('tr[data-id="' + id + '"]');
                    if (tr.length > 0) {
                        tr.fadeOut(500, function () {
                            jQuery(tr).remove();

                        });
                    }
                }
            });
        }
    });
});
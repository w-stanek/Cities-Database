// temperature display scripts
$('.pop').hover(
    function (event) {
        var el = $(this);
        var city = $(this).attr('name')
        var fetchData = "loading"
        $.ajax({
            url: 'http://api.openweathermap.org/data/2.5/weather?q=' + city + '&APPID=ad9c0285bac951a045290f4ca2e702b8&units=metric',
            type: "GET",
            dataType: "jsonp",
            cache: true,
            success: function (data) {
                console.log(data)
                fetchData = data['main']['temp'] + "°C"
                el.popover({
                    title: "Teplota",
                    content: fetchData,
                    placement: "left",
                    cache: true,
                }).popover('show');
            },
            error: function () {
                fetchData = "Cannot load data"
                el.popover({
                    title: "Teplota",
                    content: fetchData,
                    placement: "left",
                    cache: true,
                }).popover('show')
            },
        })
    },

    function () { }
);

function DisplayPopup(data) {
     el.popover({
                    title: "Teplota",
                    content: fetchData,
                    placement: "left",
                    cache: true,
                }).popover('show')

}
$('.pop').mouseleave(function (event) {
    var el = $(this);
    el.popover('hide')
})

//save modal scripts
$('#btnSave').click(function () {
    var data = $('#CityData').serialize()
    console.log(data)
    $.ajax({
        type: "POST",
        url: "/Home/CreatePost",
        data: data,
        success: function () {
            window.location ="/Home"
        }
    })
})

//delete modal scripts
var Confirm = function (id) {
    $('#cityId').val(id)
    $.ajax({
        type: "POST",
        url: "/Home/GetCityById",
        data: { id: id },
        success: function (result) {
            $('#name').html(result['name'])
            $('#population').html(result['population'])
        }

    })
    $('#modal-delete').modal('show')
 
}

$('#btnDelete').click(function () {
    var _id = $('#cityId').val()
    $.ajax({
        type: "POST",
        url: "/Home/Delete",
        data: { id: _id },
        success: function (result) {
            $('#modal-delete').modal('hide')
            $('#cityId').val(null)
            window.location = "/Home"
        } 
        
    })
})

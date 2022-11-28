(function ($) {
    sepetBilgileriniCek();
    // Fix cart dropdown from closing
    $('.cart-dropdown').on('click', function (e) {
        e.stopPropagation();
    });
    // Mobile Nav toggle
    $('.menu-toggle > a').on('click', function (e) {
        e.preventDefault();
        $('#responsive-nav').toggleClass('active');
    })
})(jQuery);
function sepeteEkle(itemCode,id) {
    var theData = {
        itemCode: itemCode,
        miktar: ($("#miktar" + id).val().trim() == "") ? "1" : $("#miktar" + id).val().trim(),
        LineType:"1"
    }
    loading(true);
    $.ajax({
        url: '/Products/SepeteEkle/',
        type: 'POST',
        dataType: 'text',
        data: theData,
        success: function (data) {
            var result = JSON.parse(data);
            if (Boolean(result.IsSuccessful)) {
                onayMesaji(result.Content);
                sepetBilgileriniCek();
            } else {
                hataMesajı(result.Content);
            }

            loading(false);
        }
    });
}


function sepettenSil(logicalref) {
    var theData = {
        LOGICALREF: logicalref,
    }
    $.ajax({
        url: '/Products/SepettenSil/',
        type: 'POST',
        dataType: 'text',
        data: theData,
        success: function (data) {
            var result = JSON.parse(data);
            if (Boolean(result.IsSuccessful)) {
                sepetBilgileriniCek() 
            } else {
                hataMesajı(result.Content);
            }

        }
    });
}

function sepetBilgileriniCek() {
    $("#sepetIcerigi .cart-list").html("Sepetteki Ürünleri Yükleniyor Lütfen Bekleyiniz.");
    $.ajax({
        url: '/Products/SepetCek/',
        type: 'POST',
        dataType: 'text',
        success: function (data) {
            var result = JSON.parse(data);
            $("#sepetMiktari").html(result.length);
            $("#sepetIcerigi .cart-list").html("");
            var araToplam = 0;
            var kdvToplam = 0;
            var tevkifatToplam = 0;
            for (var i = 0; i < result.length; i++) {
                var imgUrl = (result[i].Url.length == 0) ? "/img/urun-resim-yok.png" : "data:image/png;base64," + result[i].Url;

                $("#sepetIcerigi .cart-list").append('' +
                    '<div class="product-widget">' +
                    '<div class="product-img">' +
                    '<img src="' + imgUrl + '" alt="">' +
                    '</div>' +
                    '<div class="product-body">' +
                    '<h3 class="product-name"><a href="#">' + result[i].UrunAdi + '</a></h3>' +
                    '<h4 class="product-price"><span class="qty">' + result[i].Miktar + 'x</span>' + formatMoney(result[i].IndirimliFiyat) + 'TL = ' + formatMoney(parseFloat(result[i].Miktar) * parseFloat(result[i].IndirimliFiyat)) + 'TL</h4>' +
                    '</div>' +
                    '<button class="delete" onclick="sepettenSil(' + result[i].LOGICALREF + ')"><i class="fa fa-close"></i></button>' +
                    '</div>' +
                    '');
                araToplam += parseFloat(result[i].IndirimliFiyat) * parseFloat(result[i].Miktar);
                if (result[i].TevkifatKodu == "" || result[i].TevkifatKodu == null) {
                    kdvToplam += parseFloat(result[i].IndirimliFiyat) * (parseFloat(result[i].KdvOrani) / 100) * parseFloat(result[i].Miktar);

                } else {
                    kdvToplam += (parseFloat(result[i].IndirimliFiyat) * (parseFloat(result[i].KdvOrani) / 100)) * parseFloat(result[i].Miktar);
                    tevkifatToplam += (parseFloat(result[i].IndirimliFiyat) * (parseFloat(result[i].KdvOrani) / 100) * (parseFloat(result[i].TevkifatKodu.split('/')[0]) / parseFloat(result[i].TevkifatKodu.split('/')[1]))) * parseFloat(result[i].Miktar);
  }
            }
            $("#sepetTutari").html('' +
                '<h5>ARA TOPLAM: <label style="min-width:120px">' + formatMoney(araToplam) + 'TL</label></h5>' +
                '<h5>KDV TOPLAM: <label style="min-width:120px">' + formatMoney(kdvToplam) + 'TL</label></h5>'+
                '<h5>TEVKİFAT TOPLAM: <label style="min-width:120px">'+((tevkifatToplam!=0)?'-' + formatMoney(tevkifatToplam) + 'TL':'')+'</label></h5>'+
                '<h5>GENEL TOPLAM: <label style="min-width:120px">' + formatMoney(araToplam + kdvToplam - tevkifatToplam) + 'TL</label></h5>'+
                '');
           
        }
    });
}


function formatMoney(n, c, d, t) {//sayı noktalı olarak gelmeli
    var c = isNaN(c = Math.abs(c)) ? 2 : c,
        d = d == undefined ? "," : d,
        t = t == undefined ? "." : t,
        s = n < 0 ? "-" : "",
        i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
        j = (j = i.length) > 3 ? j % 3 : 0;

    return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
}

function onayMesaji(mesaj) {
    Swal.fire(
        'BAŞARILI!',
        mesaj,
        'success'
    )
}

function hataMesajı(mesaj) {
    Swal.fire(
        'HATA!',
        mesaj,
        'error'
    )
}

function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)), //aksilik olmadan decodeURIComponent fonksiyonu ile url metni oku
        sURLVariables = sPageURL.split('&'), //dizi haline getir
        sParameterName,
        i;
    for (i = 0; i < sURLVariables.length; i++) { //parametreler icerisinde dongu ile gezin
        sParameterName = sURLVariables[i].split('=');
        if (sParameterName[0] === sParam) { //istenilen parametre dizide, urlde var sa
            return sParameterName[1] === undefined ? true : sParameterName[1]; //parametre icerigi bos degilse veriyi geriye donder
        }
    }
}


function TextboxaHarfGirisiniEngelleVirgulHaric(myfield, e, dec) {
    var key;
    var keychar;

    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    keychar = String.fromCharCode(key);
    // control keys
    if ((key == null) || (key == 0) || (key == 8) ||
        (key == 9) || (key == 13) || (key == 27) || (key == 44))
        return true;

    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;

    // decimal point jump
    else if (dec && (keychar == ".")) {
        myfield.form.elements[dec].focus();
        return false;
    }
    else
        return false;
}


function TextboxaHarfGirisiniEngelle(myfield, e, dec) {
    var key;
    var keychar;

    if (window.event)
        key = window.event.keyCode;
    else if (e)
        key = e.which;
    else
        return true;
    keychar = String.fromCharCode(key);
    // control keys
    if ((key == null) || (key == 0) || (key == 8) ||
        (key == 9) || (key == 13) || (key == 27) || (key == 46))
        return true;

    // numbers
    else if ((("0123456789").indexOf(keychar) > -1))
        return true;

    // decimal point jump
    else if (dec && (keychar == ".")) {
        myfield.form.elements[dec].focus();
        return false;
    }
    else
        return false;
}


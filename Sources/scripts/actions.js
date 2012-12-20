$(document).ready(function () {

    $(".sideCol .menu .hasSubMenu > a ").not('.navUrl').click(function () {
        $(this).parent().children("ul").toggle("fast");
        $(this).parent().toggleClass("expanded");
        return false;
    });

    $(".fancybox").fancybox();

    $('.ad-gallery').adGallery();
    $('.ad-thumb-list').prepend('<a class="tmp"></a>');
    $(".ad-gallery").on("click", ".ad-image", function () {
        var path = $(this).find("img").attr("src");
        $('.ad-thumb-list .tmp').attr('href', path);
        var items = $(".ad-thumb-list a").not('.ad-active');
        $.fancybox.open(items, {
            openEffect: 'elastic',
            openSpeed: 150,
            closeEffect: 'elastic',
            closeSpeed: 150
        });
    });

    $('#mycarousel').jcarousel({ scroll: 1 });

});

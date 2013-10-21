$(document).ready(function () {
    $('#description li').on('click', 'h3', function () {
        $(this).closest('#description').find('p','#features').slideToggle();
    });
});
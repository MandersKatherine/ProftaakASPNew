$(document).ready(function () {
    var $loading = $("#loading").hide();

    $(".ShowCommentsById").on("click",
        function () {
            var $targetItem = $(this).attr("data-item");
            var $loadingcomments = $("#loadingcomments-" + $targetItem).hide();
            var $classname = $(".showComments" + "-" + $targetItem).attr("data-comment");

            var self = $(this);

            $(".showComments-" + $classname).html("");
            $loadingcomments.show();
            $.ajax({
                    url: "/Bijdrage/LoadBerichtenByPostId/" + $targetItem,
                    type: "GET"
                })
                .done(function (partialViewResult) {
                    $(".showComments-" + $classname).html(partialViewResult);
                    $loadingcomments.hide();
                    self.hide();
                });
        });
});



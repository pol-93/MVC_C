application = {};

application = {
    init: function () {
        this.hideComments();
        this.showComments();
        this.loadComments();
    },
    hideComments: function () { 
        $(document).on("click", ".hide-replys", function () {
            $(this).attr("disabled", "disabled");
            $(this).closest(".comment-container").find(".user-comment").slideUp(500);
            $(this).removeClass("hide-replys");
            $(this).addClass("show-replys");
            $(this).find("span").text("show replys");
            $self = $(this);
            setTimeout(function () {
                console.log("entro");
                $self.removeAttr("disabled");
            },500)
        });
    },
    showComments: function() {
        $(document).on("click", ".show-replys", function () {
            $(this).attr("disabled", "disabled");
            $(this).closest(".comment-container").find(".user-comment").slideDown(500);
            $(this).removeClass("show-replys");
            $(this).addClass("hide-replys");
            $(this).find("span").text("hide replys");
            $self = $(this);
            setTimeout(function () {
                $self.removeAttr("disabled");
            }, 500)
        });
    },
    loadComments: function() {
        $(document).on("click", ".load-replys", function () {
            console.log($(this).data("comment").commentId);
            console.log($(this).data("comment").PictureId);
            info = JSON.stringify({ "CommentId": "hola", "pictureId": "adeu" });
            console.log("wtf" + info);
            $.ajax({
                type: "POST",
                url: "loadComments",
                data: info,
                dataType: "json",
                success: function (data) {
                    console.log(data);
                }, error: function (error) {
                    console.log(error);
                }
            }).done(function (info) {
                console.log(info);
            });
        });
    }
}

$(document).ready(application.init());
document.querySelector(".list-phim_base64").style.display = 'none';
        //var base64String = document.querySelector(".list-phim_base64");
        //console.log(base64String);
        //// Tạo đối tượng ảnh từ chuỗi base64
        //var img = new Image();
        //img.src = "data:image/png;base64," + base64String;
        //img.onload = function () {
        //    document.getElementById("my-image").src = img.src;
        //};





<div class="list-phim_around">
    @foreach (EudoraCinema.Models.PhimEntity item in Model)
    {
                <div class="list-phim">
                    <div class="list-phim_base64" style="width:100%; border-radius:8px;"">@item.sAnh</div>
                    <div class="list-phim_tenphim"><a href="#">@item.sTenphim</a></div>
                    <div>@item.sThoiluong</div>
                    <div>@item.sDaodien</div>
                    <button class="btn btn-muave">MUA VÉ</button>
                </div>
            }
        </div >

    <script>
        var elements = document.querySelectorAll(".list-phim_base64");

        for (var i = 0; i < elements.length; i++) {
            elements[i].style.display = 'none';

        var base64String = elements[i].textContent;
        var img = new Image();

        img.onload = function (event) {
            this.src = event.target.src;
                };

        img.src = "data:image/jpeg;base64," + base64String;
        elements[i].parentNode.insertBefore(img, elements[i]);
            }
    </script>
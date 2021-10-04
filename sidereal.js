	
	window.onload = function(){
    var b = document.getElementById("enter");
	b.addEventListener("click", authentication);
}
	

	function authentication(){
		
		let l = document.getElementById("username").value;
        let p = document.getElementById("password").value;
			
		l = hex_md5(l);
		p = hex_md5(p);
		
		if (l == "a384b6463fc216a5f8ecb6670f86456a" & p == "e00cf25ad42683b3df678c61f42c6bda") {
			location.href = "https://junkbeat.github.io/Closed/u/user.html";
		}
	}
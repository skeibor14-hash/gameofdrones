window.$scope = "";
window.angular_set = ( $nombre, $valor ) => {
	if(
		window.$scope
		&& window.$scope.$digest
	){
		window.$scope[ $nombre ] = $valor;
		window.$scope.$digest();
	}
};
// Bootstrap table - test of `export selected` (to csv) with server side pagination. Created to help answer https://github.com/wenzhixin/bootstrap-table/issues/2220, release 1.10.1 and onwards

$(function() {
  var $table = $('#table');
  $('#toolbar').find('select').change(function() {
// When the stripped button is clicked, clone the existing source
var $clonedTable = $table.clone();
// Strip your empty characters from the cloned table (hidden didn't seem to work since the cloned table isn't visible)
$clonedTable.find('[style*="display: none"]').remove();
    $clonedTable.bootstrapTable('refreshOptions', {
	
      exportDataType: $(this).val()
	
    });
  });

  $('#getAllSelections').click(function(e) {
    e.preventDefault();
    var selectedData = $table.bootstrapTable('getAllSelections');
    console.log('selectedData',selectedData);
    $table.bootstrapTable('load',selectedData);
  });
  
});

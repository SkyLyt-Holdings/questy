import * as React from 'react';
import Check from '@material-ui/icons/Check';
import ArrowDownward from '@material-ui/icons/ArrowDownward';
import ChevronLeft from '@material-ui/icons/ChevronLeft';
import ChevronRight from '@material-ui/icons/ChevronRight';
import Clear from '@material-ui/icons/Clear';
import FilterList from '@material-ui/icons/FilterList';
import FirstPage from '@material-ui/icons/FirstPage';
import LastPage from '@material-ui/icons/LastPage';
import Search from '@material-ui/icons/Search';
import ViewColumn from '@material-ui/icons/ViewColumn';


const materialTableIcons = {
      Check: React.forwardRef((props, ref) => <Check {...props} ref={ref} />),
      Clear: React.forwardRef((props, ref) => <Clear {...props} ref={ref} />),
	Filter: React.forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
      FirstPage: React.forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
      LastPage: React.forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
      NextPage: React.forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
      PreviousPage: React.forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
      ResetSearch: React.forwardRef((props, ref) => <Clear {...props} ref={ref} />),
      Search: React.forwardRef((props, ref) => <Search {...props} ref={ref} />),
      SortArrow: React.forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
      ViewColumn: React.forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)
};

export default materialTableIcons
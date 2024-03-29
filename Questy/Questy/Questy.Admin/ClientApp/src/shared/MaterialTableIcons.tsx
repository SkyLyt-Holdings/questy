import { forwardRef } from 'react';
import * as React from 'react';

import AddBox from '@mui/icons-material/AddBox';
import ArrowDownward from '@mui/icons-material/ArrowDownward';
import Check from '@mui/icons-material/Check';
import ChevronLeft from '@mui/icons-material/ChevronLeft';
import ChevronRight from '@mui/icons-material/ChevronRight';
import Clear from '@mui/icons-material/Clear';
import DeleteOutline from '@mui/icons-material/DeleteOutline';
import Edit from '@mui/icons-material/Edit';
import FilterList from '@mui/icons-material/FilterList';
import FirstPage from '@mui/icons-material/FirstPage';
import LastPage from '@mui/icons-material/LastPage';
import Remove from '@mui/icons-material/Remove';
import SaveAlt from '@mui/icons-material/SaveAlt';
import Search from '@mui/icons-material/Search';
import ViewColumn from '@mui/icons-material/ViewColumn';


const materialTableIcons = {
      Add: forwardRef((props: any, ref) => <AddBox {...props} ref={ref} />),
      Check: forwardRef((props: any, ref) => <Check {...props} ref={ref} />),
      Clear: forwardRef((props: any, ref) => <Clear {...props} ref={ref} />),
      Delete: forwardRef((props: any, ref) => <DeleteOutline {...props} ref={ref} />),
      DetailPanel: forwardRef((props: any, ref) => <ChevronRight {...props} ref={ref} />),
      Edit: forwardRef((props: any, ref) => <Edit {...props} ref={ref} />),
      Export: forwardRef((props: any, ref) => <SaveAlt {...props} ref={ref} />),
      Filter: forwardRef((props: any, ref) => <FilterList {...props} ref={ref} />),
      FirstPage: forwardRef((props: any, ref) => <FirstPage {...props} ref={ref} />),
      LastPage: forwardRef((props: any, ref) => <LastPage {...props} ref={ref} />),
      NextPage: forwardRef((props: any, ref) => <ChevronRight {...props} ref={ref} />),
      PreviousPage: forwardRef((props: any, ref) => <ChevronLeft {...props} ref={ref} />),
      ResetSearch: forwardRef((props: any, ref) => <Clear {...props} ref={ref} />),
      Search: forwardRef((props: any, ref) => <Search {...props} ref={ref} />),
      SortArrow: forwardRef((props: any, ref) => <ArrowDownward {...props} ref={ref} />),
      ThirdStateCheck: forwardRef((props: any, ref) => <Remove {...props} ref={ref} />),
      ViewColumn: forwardRef((props: any, ref) => <ViewColumn {...props} ref={ref} />)
} as any;

export default materialTableIcons
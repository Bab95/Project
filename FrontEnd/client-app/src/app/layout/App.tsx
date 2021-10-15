import React, { Fragment, useEffect, useState } from 'react';
import './../../App.css';
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Activity } from './../models/activity';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then((response:any) => {
      setActivities(response.data);
    })
  }, []);

  function handleSelectActivity(id : string){
    setSelectedActivity(activities.find(activity => activity.id ===id))
  }

  function cancelSelectedActivity(){
    setSelectedActivity(undefined)
  }

  function handleFormOpen(id?:string) {
    id ? handleSelectActivity(id) : cancelSelectedActivity();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditActivity(activity : Activity){
    activity.id ? setActivities([...activities.filter(x => x.id !== activity.id), activity])
    : setActivities([...activities, activity]);
    setEditMode(false);
    setSelectedActivity(activity)
  } 

  return (
    <>
      <NavBar openForm={handleFormOpen}/>
      <Container style={{marginTop:'7em'}}>
        <ActivityDashboard 
          activities = {activities}
          selectedActivity = {selectedActivity}
          selectActivity = {handleSelectActivity}
          cancelSelectActivity={cancelSelectedActivity}
          editMode = {editMode}
          openForm = {handleFormOpen}
          closeForm = {handleFormClose}
          createOrEdit = {handleCreateOrEditActivity}
          />
      </Container>
    </>
  );
}

export default App;

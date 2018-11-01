using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Person
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public int Age;

    [SerializeField]
    public int Mood;

    [SerializeField]
    public bool Hired;
}

public class EmployeeMenu : MonoBehaviour {
    
    public Text nameText;
    public Text ageText;
    public Text moodText;
    public Text hiredPeople;
    public Person[] employees;
    public List<Person> hiredEmployees = new List<Person>();
    public Person currentPerson;
    public Button hireButton;
    private int personIndex = 0;

	// Use this for initialization
	void Start () {
        PickPerson(0);
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void SetText()
    {
        nameText.text = currentPerson.Name;
        ageText.text = currentPerson.Age.ToString();
        moodText.text = currentPerson.Mood.ToString();
    }

    public Person PickRandomPerson()
    {
        personIndex = Random.Range(0, employees.Length);
        SetText();
        return employees[personIndex];
    }

    public void PickNextPerson()
    {
        personIndex++;

        if (personIndex < employees.Length || personIndex == employees.Length - 1)
        {    
            PickPerson(personIndex);
        }
        else
        {
            personIndex = 0;
            PickPerson(0);
        }
    }

    private void PickPerson(int index)
    {
        currentPerson = employees[personIndex];
        SetText();
        ToggleHireButton();
    }

    private void ToggleHireButton()
    {
        hireButton.gameObject.SetActive(!currentPerson.Hired);
    }

    public void HirePerson()
    {
        Person employee = employees[personIndex];
        employee.Hired = true;
        hiredEmployees.Add(employees[personIndex]);
        hiredPeople.text += employee.Name;
    }
}

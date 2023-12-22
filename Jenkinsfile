UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe"
pipeline {
    parameters {
        choice(name: 'TYPE', choices: ['Debug', 'Release', 'Publisher'], description: 'Do you want cheats or speed?')
        choice(name: 'BUILD', choices: ['Fast', 'Deploy', 'HealthCheck'], description: 'Fast builds run minimal tests and make a build. HealthCheck builds run more automated tests and are slower. Deploy builds are HealthChecks + a deploy.')
        booleanParam(name: 'CLEAN', defaultValue: false, description: 'Tick to removed cached files - will take an eon')
        booleanParam(name: 'SKIP_PLAYMODE_TESTS', defaultValue: false, description: 'In an emergency, to allow Deploy builds to work with a failing playmode test')
    }
    agent {
        label "GitPractice01"
        customWorkspace 'workspace\\GitPractice01'
    }
    options {
        timestamps()
        timeout(time: 10, unity: 'MINUTES')
    }
    stages {
        stage('Clean') {
            when {
                expression{ return params.CLEAN }
            }
            steps {
                bat "if exist Library (rmdir Library /s /q)"
                bat "if exist Temp (rmdir Temp /s /q)"
            }
        }
    }
}
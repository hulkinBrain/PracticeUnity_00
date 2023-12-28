pipeline {
    agent any
    environment {
        UNITY_PATH = "C:\\Program Files\\Unity\\Hub\\Editor\\2022.3.16f1\\Editor\\Unity.exe"
    }
    options {
        timestamps()
        timeout(time: 5, unit: 'MINUTES')
    }
    stages {
        stage('ECHO VARS') {
            steps {
                echo "[ECHO] ${JOB_NAME}, ${JOB_BASE_NAME}, ${BUILD_TAG}"
            }
        }
        stage('BUILD') {
            steps {
                bat "\"${UNITY_PATH}\" -nographics -batchmode -quit -executeMethod JenkinsBuild.BuildDefault ${JOB_NAME} ."
            }
        }
        stage('TEST') {
            environment {
                PATH_TO_BALLMOVELOG = "C:\\Users\\vmpro\\Documents\\UnityProjects\\BallMoveLog.txt"
            }
            steps {
                bat "\"${JENKINS_HOME}/jobs/${JOB_BASE_NAME}/builds/${BUILD_NUMBER}/output/${JOB_NAME}.exe\" -nographics -batchmode -logMode \"${PATH_TO_BALLMOVELOG}\""
            }
        }
    }
}
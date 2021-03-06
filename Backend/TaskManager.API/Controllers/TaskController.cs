﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.Application.Interfaces;

namespace TaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskAppService _taskService;

        public TaskController(ITaskAppService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetById/{id}")]
        public ResponseMessage GetById(int id)
        {
            try
            {
                var board = _taskService.GetById(id);

                if (board != null)
                {
                    return new ResponseMessage(true, board, "", HttpStatusCode.OK);
                }

                return new ResponseMessage(true, null, "Task not found!", HttpStatusCode.OK);

            }
            catch (Exception err)
            {
                return new ResponseMessage(false, err, err.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpGet("GetAllByBoardId/{boardid}")]
        public ResponseMessage GetAllByBoardId(int boardId)
        {
            try
            {
                var tasks = _taskService.GetAllByBoardId(boardId);

                if (tasks != null)
                {
                    return new ResponseMessage(true, tasks, "", HttpStatusCode.OK);
                }

                return new ResponseMessage(true, null, "Task not found!", HttpStatusCode.OK);

            }
            catch (Exception err)
            {
                return new ResponseMessage(false, err, err.Message, HttpStatusCode.BadRequest);
            }
        }


        [HttpPost("add")]
        public async Task<ResponseMessage> Add(Domain.Entities.TaskEntity task)
        {
            try
            {
                var storedBoard = await _taskService.Add(task);
                return new ResponseMessage(true, storedBoard, "Task created with success!", HttpStatusCode.OK);
            }
            catch (Exception err)
            {
                return new ResponseMessage(false, null, err.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpPut("update")]
        public async Task<ResponseMessage> Update(Domain.Entities.TaskEntity task)
        {
            try
            {
                var storedTask = await _taskService.Update(task);
                return new ResponseMessage(true, storedTask, "Task updated with success!", HttpStatusCode.OK);
            }
            catch (Exception err)
            {
                return new ResponseMessage(false, null, err.Message, HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ResponseMessage> Delete(int id)
        {
            try
            {
                var storedTask = await _taskService.DeleteAsync(id);
                return new ResponseMessage(true, null, "Task removed with success!", HttpStatusCode.OK);
            }
            catch (Exception err)
            {
                return new ResponseMessage(false, null, err.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}